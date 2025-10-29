CREATE DATABASE QLQA;
GO
USE QLQA;
GO


select * from MonAn
-- ==========================
--  BẢNG BÀN ĂN
-- ==========================
CREATE TABLE BanAn (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Trống',
    SoCho INT NOT NULL CHECK (SoCho > 0)
);
GO

-- ==========================
--  BẢNG TÀI KHOẢN
-- ==========================
CREATE TABLE TaiKhoan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TenNguoiDung NVARCHAR(50) NOT NULL UNIQUE,
    TenHienThi NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL
);
GO

-- ==========================
--  BẢNG MÓN ĂN
-- ==========================
CREATE TABLE MonAn (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TenMonAn NVARCHAR(50) NOT NULL,
    DonGia DECIMAL(15,2) NOT NULL CHECK (DonGia > 0),
    HinhAnh NVARCHAR(255) NULL -- cho phép null để tránh lỗi khi chưa có hình
);
GO

-- ==========================
--  BẢNG HÓA ĐƠN
-- ==========================
CREATE TABLE HoaDon (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    IDBanAn INT NOT NULL,
    TinhTrang INT NOT NULL CHECK (TinhTrang IN (0,1)), -- 0: chưa thanh toán, 1: đã thanh toán
    FOREIGN KEY (IDBanAn) REFERENCES BanAn(ID)
);
GO

-- ==========================
--  BẢNG CHI TIẾT HÓA ĐƠN
-- ==========================
CREATE TABLE CTHoaDon (
    IDHoaDon INT NOT NULL,
    IDMonAn INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(15,2) NOT NULL CHECK (DonGia >= 0),
    ThanhTien AS (SoLuong * DonGia) PERSISTED, -- tính tự động
    PRIMARY KEY (IDHoaDon, IDMonAn),
    FOREIGN KEY (IDHoaDon) REFERENCES HoaDon(ID),
    FOREIGN KEY (IDMonAn) REFERENCES MonAn(ID)
);
GO

-- ==========================
--  BẢNG KHO HÀNG
-- ==========================
CREATE TABLE KhoHang (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TenNguyenLieu NVARCHAR(50) NOT NULL,
    SoLuongTon DECIMAL(15,2) NOT NULL CHECK (SoLuongTon >= 0),
    DonViTinh NVARCHAR(30) NOT NULL,
    GiaNhap DECIMAL(15,2) NOT NULL CHECK (GiaNhap >= 0),
    NgayNhap DATETIME DEFAULT GETDATE()
);
GO

-- ==========================
--  BẢNG CHI TIẾT NGUYÊN LIỆU
-- ==========================
CREATE TABLE CTNguyenLieu (
    IDNguyenLieu INT NOT NULL,
    IDMonAn INT NOT NULL,
    SoLuong DECIMAL(15,2) NOT NULL CHECK (SoLuong > 0),
    PRIMARY KEY (IDNguyenLieu, IDMonAn),
    FOREIGN KEY (IDNguyenLieu) REFERENCES KhoHang(ID),
    FOREIGN KEY (IDMonAn) REFERENCES MonAn(ID)
);
GO

-- ==========================
--  BẢNG DOANH THU (TỔNG HỢP THEO NGÀY)
-- ==========================
CREATE TABLE DoanhThu (
    Ngay DATE PRIMARY KEY,
    TongSoHoaDon INT NOT NULL DEFAULT 0,
    TongDoanhThu DECIMAL(18,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(100) NULL
);
GO

----------------------------
-- BẢNG TÀI KHOẢN
----------------------------
INSERT INTO TaiKhoan (TenNguoiDung, TenHienThi, MatKhau)
VALUES 
(N'admin', N'Quản trị viên', N'123'),
(N'ngocanh', N'Ngọc Ánh', N'123'),
(N'khanh', N'Khánh', N'123');
GO

----------------------------
-- BẢNG BÀN ĂN
----------------------------
INSERT INTO BanAn (TenBan, TinhTrang, SoCho)
VALUES
(N'Bàn 1', N'Trống', 4),
(N'Bàn 2', N'Có khách', 4),
(N'Bàn 3', N'Trống', 6),
(N'Bàn 4', N'Có Khách', 2),
(N'Bàn 5', N'Trống', 8);
GO

----------------------------
-- BẢNG MÓN ĂN
----------------------------
INSERT INTO MonAn (TenMonAn, DonGia, HinhAnh)
VALUES
(N'Cơm gà xối mỡ', 45000, N'comgaxoimo.jpg'),
(N'Phở bò đặc biệt', 55000, N'phobo.jpg'),
(N'Hủ tiếu Nam Vang', 50000, N'hutieu.jpg'),
(N'Lẩu thái hải sản', 180000, N'lauthai.jpg'),
(N'Trà đá', 5000, N'trada.jpg');
GO

select * from TaiKhoan
----------------------------
-- BẢNG KHO HÀNG (Nguyên liệu)
----------------------------
INSERT INTO KhoHang (TenNguyenLieu, SoLuongTon, DonViTinh, GiaNhap, NgayNhap)
VALUES
(N'Thịt gà', 20, N'kg', 70000, GETDATE()),
(N'Thịt bò', 15, N'kg', 150000, GETDATE()),
(N'Tôm tươi', 10, N'kg', 180000, GETDATE()),
(N'Rau xanh', 25, N'kg', 20000, GETDATE()),
(N'Mì gói', 100, N'gói', 3000, GETDATE()),
(N'Trà khô', 5, N'kg', 90000, GETDATE());
GO

----------------------------
-- BẢNG CHI TIẾT NGUYÊN LIỆU
----------------------------
INSERT INTO CTNguyenLieu (IDNguyenLieu, IDMonAn, SoLuong)
VALUES
(1, 1, 0.2),  -- Cơm gà dùng 0.2kg thịt gà
(2, 2, 0.15), -- Phở bò dùng 0.15kg thịt bò
(4, 2, 0.1),  -- Phở bò dùng 0.1kg rau
(3, 4, 0.3),  -- Lẩu thái dùng 0.3kg tôm
(4, 4, 0.2),  -- Lẩu thái dùng 0.2kg rau
(6, 5, 0.02); -- Trà đá dùng 0.02kg trà khô
GO

----------------------------
-- BẢNG HÓA ĐƠN
----------------------------
INSERT INTO HoaDon (NgayLap, IDBanAn, TinhTrang)
VALUES
('2025-10-25 10:30', 2, 1),  -- đã thanh toán
('2025-10-25 11:15', 3, 1),  -- đã thanh toán
('2025-10-26 09:00', 4, 0);  -- chưa thanh toán
GO

----------------------------
-- BẢNG CHI TIẾT HÓA ĐƠN
----------------------------
-- Hóa đơn 1: Bàn 2
INSERT INTO CTHoaDon (IDHoaDon, IDMonAn, SoLuong, DonGia)
VALUES
(1, 1, 2, 45000), -- 2 phần Cơm gà
(1, 5, 2, 5000);  -- 2 ly Trà đá

-- Hóa đơn 2: Bàn 3
INSERT INTO CTHoaDon (IDHoaDon, IDMonAn, SoLuong, DonGia)
VALUES
(2, 2, 1, 55000), -- 1 tô Phở bò
(2, 3, 1, 50000), -- 1 tô Hủ tiếu
(2, 5, 1, 5000);  -- 1 ly Trà đá

-- Hóa đơn 3: Bàn 4 (chưa thanh toán)
INSERT INTO CTHoaDon (IDHoaDon, IDMonAn, SoLuong, DonGia)
VALUES
(3, 4, 1, 180000), -- 1 nồi Lẩu thái
(3, 5, 2, 5000);   -- 2 ly Trà đá
GO

----------------------------
-- BẢNG DOANH THU
----------------------------
-- Tổng hợp theo ngày (giả sử từ dữ liệu hóa đơn)
INSERT INTO DoanhThu (Ngay, TongSoHoaDon, TongDoanhThu, GhiChu)
VALUES
('2025-10-25', 2, 45000*2 + 5000*2 + 55000 + 50000 + 5000, N'Doanh thu thứ 7'),
('2025-10-26', 1, 0, N'Có 1 hóa đơn đang chờ thanh toán');
GO

 

