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



ALTER TABLE HoaDon ADD ID_New INT IDENTITY(1,1);
insert into TaiKhoan(ID, TenNguoiDung, TenHienThi, MatKhau)
values (1, N'Admin', N'Admin', '123456789')
