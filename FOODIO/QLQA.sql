create database QuanLyQuanAn
Go

use QuanLyQuanAn
go

--Ban An
Create Table BanAn
(	
	ID int primary key,
	TenBan nvarchar(50) not null,
	TinhTrang nvarchar(50) not null,
	SoCho int not null
)
Go
-- Tai Khoan
Create table TaiKhoan(
	ID int primary key,
	TenNguoiDung nvarchar(50)not null,
	TenHienThi nvarchar(50)not null,
	MatKhau nvarchar(50)not null
)
Go
--Món Ăn
Create table MonAn(
	ID int primary key,
	TenMonAn nvarchar(50) not null,
	DonGia decimal(15,2)not null,
	HinhAnh nvarchar(50)not null
	)
Go
--Hóa Đơn
Create table HoaDon(
	ID int primary key,
	NgayLap Datetime default getdate(),
	IDBanAn int not null,
	TinhTrang Int not null, -- 1:Đã thanh toán && 0:Chưa thanh toán
	--TongTien decimal(15,2)not null
	foreign key (IDBanAn) references BanAn(ID)
	)
	Go
--Chi Tiết Hóa Đơn
Create table CTHoaDon(
	IDHoaDon int,
	IDMonAn int,
	SoLuong int not null,
	DonGia decimal(15,2) not null,
	ThanhTien decimal(15,2) not null,
	primary key(IDHoaDon,IDMonAn),
	foreign key (IDHoaDon) references HoaDon(ID),
	foreign key (IDMonAn) references MonAn(ID)
	)
	Go
--Kho
create table KhoHang(
	ID int primary key,
	TenNguyenLieu nvarchar(50) not null,
	SoLuongTon decimal(15,2) not null,
	DoViTinh nvarchar(30) not null,
	GiaNhap decimal (15,2) not null,
	NgayNhap Datetime default getdate()
	)
	Go
-- Chi Tiết Nguyên Liệu
create table CTNguyenLieu(
	IDNguyenLieu int,
	IDMonAn int,
	SoLuong int not null,
	primary key (IDNguyenLieu,IDMonAn),
	foreign key (IDNguyenLieu) references KhoHang(ID),
	foreign key (IDMonAn) references MonAn(ID)
	)
	Go
	CREATE TABLE DoanhThu(
    ID INT IDENTITY PRIMARY KEY,
    NgayThanhToan DATETIME NOT NULL,
    IDHoaDon INT NOT NULL,
    IDBanAn INT NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL,
    GiamGia DECIMAL(18,2) DEFAULT 0,
    ThanhTien AS (TongTien - GiamGia) PERSISTED,
    GhiChu NVARCHAR(100)
	foreign key (IDHoaDon) references HoaDon(ID),
	foreign key (IDBanAn) references BanAn(ID)
)

select * from HoaDon

select * from CTHoaDon

select * from TaiKhoan

ALTER TABLE HoaDon ADD ID_New INT IDENTITY(1,1);
insert into TaiKhoan(ID, TenNguoiDung, TenHienThi, MatKhau)
values(1, N'Admin', N'Admin', N'123456789')

INSERT INTO BanAn (ID, TenBan, TinhTrang, SoCho)
VALUES
(1, N'Bàn 1', N'Trống', 4),
(2, N'Bàn 2', N'Có khách', 6),
(3, N'Bàn 3', N'Trống', 2),
(4, N'Bàn 4', N'Có khách', 4),
(5, N'Bàn 5', N'Trống', 8);

INSERT INTO MonAn (ID, TenMonAn, DonGia, HinhAnh)
VALUES
(1, N'Phở bò', 40000, N'pho.jpg'),
(2, N'Cơm tấm sườn', 35000, N'comtam.jpg'),
(3, N'Lẩu thái', 150000, N'lauthai.jpg'),
(4, N'Bánh xèo', 30000, N'banhxeo.jpg'),
(5, N'Sinh tố bơ', 25000, N'sinhtobo.jpg');

INSERT INTO HoaDon (ID, NgayLap, IDBanAn, TinhTrang)
VALUES
(1, GETDATE(), 2, 1), -- đã thanh toán
(2, GETDATE(), 4, 0), -- chưa thanh toán
(3, GETDATE(), 1, 1);

INSERT INTO CTHoaDon (IDHoaDon, IDMonAn, SoLuong, DonGia, ThanhTien)
VALUES
(1, 1, 2, 40000, 80000),
(1, 5, 2, 25000, 50000),
(2, 2, 3, 35000, 105000),
(3, 3, 1, 150000, 150000);

INSERT INTO KhoHang (ID, TenNguyenLieu, SoLuongTon, DoViTinh, GiaNhap)
VALUES
(1, N'Bò tươi', 20, N'Kg', 200000),
(2, N'Cơm', 50, N'Kg', 15000),
(3, N'Sườn heo', 30, N'Kg', 180000),
(4, N'Tôm', 15, N'Kg', 250000),
(5, N'Trái bơ', 10, N'Kg', 80000);

INSERT INTO CTNguyenLieu (IDNguyenLieu, IDMonAn, SoLuong)
VALUES
(1, 1, 1), -- Bò tươi dùng cho phở bò
(2, 2, 1), -- Cơm cho cơm tấm
(3, 2, 1), -- Sườn cho cơm tấm
(4, 3, 1), -- Tôm cho lẩu thái
(5, 5, 1); -- Bơ cho sinh tố bơ

INSERT INTO DoanhThu (NgayThanhToan, IDHoaDon, IDBanAn, TongTien, GiamGia, GhiChu)
VALUES
(GETDATE(), 1, 2, 130000, 10000, N'Giảm giá 10k khách thân thiết'),
(GETDATE(), 3, 1, 150000, 0, N'Không giảm giá');



