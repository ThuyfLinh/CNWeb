create database CNWeb_WebMayAnh
GO


Use CNWeb_WebMayAnh
Go

----tạo bảng ----
-----NHÂN VIÊN ---------
CREATE TABLE NHANVIEN (
     IDNV INT identity,
	 TENNV NVARCHAR (100),
	 SDT INT,
	 TAIKHOAN VARCHAR(100) ,
	 MATKHAU NVARCHAR (100)
	 )
--------KHÁCH HÀNG ---------
CREATE TABLE KHACHHANG (
      IDKH INT identity ,
	  TENKH NVARCHAR (100),
	  SDT INT ,
	  EMAIL NVARCHAR (100),
	  DIACHI NVARCHAR(100)
	 
	  )
------ MÁY ẢNH ----------
CREATE TABLE MAYANH (
    IDMAY INT identity,
	TENMAY NVARCHAR (100),
	HINHANH VARCHAR (300),
	MOTA NVARCHAR(300),
	DONGIA int,
	IDLOAIMAY INT
	)
-------LOAI MÁY----------
CREATE TABLE LOAIMAY (
     IDLOAIMAY INT identity,
	 TENLMAY NVARCHAR (100)
	 )
-------ĐƠN HÀNG -------
CREATE TABLE DONHANG (
      IDDONHANG INT identity,
	  IDKH INT ,
	  NGAYLAP DATE,
	  TRANGTHAI nvarchar(300) not null default N'Chưa xử lý'
	  )
------CT ĐƠN HÀNG -------
CREATE TABLE CTDONHANG (
	 IDDONHANG INT not null,
	 IDMAY INT not null ,
	 DONGIA int ,
	 SOLUONG INT 
	 )
-----------------------------

-------- TẠO KHÓA CHÍNH -----------
 ALTER TABLE [dbo].[NHANVIEN] ADD CONSTRAINT PK_NHANVIEN PRIMARY KEY(IDNV)
 ALTER TABLE [dbo].[KHACHHANG] ADD CONSTRAINT PK_KHACHHANG PRIMARY KEY (IDKH)
 ALTER TABLE [dbo].[MAYANH] ADD CONSTRAINT PK_MAYANH PRIMARY KEY (IDMAY)
 ALTER TABLE [dbo].[LOAIMAY] ADD CONSTRAINT PK_LOAIMAY PRIMARY KEY (IDLOAIMAY)
 ALTER TABLE [dbo].[DONHANG] ADD CONSTRAINT PK_DONHANG PRIMARY KEY (IDDONHANG)
 
 ---- kháo ngoại ---
ALTER TABLE [dbo].[DONHANG] ADD CONSTRAINT FK_donhang_IDKH FOREIGN KEY(IDKH) REFERENCES[dbo].[KHACHHANG](IDKH)
ALTER TABLE [dbo].[CTDONHANG] ADD CONSTRAINT FK_CTDONHANG_IDDH FOREIGN KEY(IDDONHANG) REFERENCES [dbo].[DONHANG](IDDONHANG)
ALTER TABLE [dbo].[CTDONHANG] ADD CONSTRAINT FK_CTDONHANG_IDMAY FOREIGN KEY(IDMAY) REFERENCES [dbo].[MAYANH](IDMAY)
ALTER TABLE [dbo].[MAYANH] ADD CONSTRAINT FK_IDLAOIANH_IDMAY FOREIGN KEY(IDLOAIMAY) REFERENCES [dbo].[LOAIMAY](IDLOAIMAY)
--------------------

ALTER TABLE dbo.CTDONHANG ADD CONSTRAINT PK_CTDONHANG PRIMARY KEY (IDDONHANG,IDMAY)

------------------
INSERT  [dbo].[KHACHHANG]
values(N'Vũ Thị Huê' , 0394249888 , N'hue1234@gmail.com' , N'Nam Định'),
      (N'Phạm Minh Đức' , 0394449999 , N'duc5678@gmail.com' , N'Hà Nội' ), 
      (N'Vũ Thị Thu Hà' , 0374348888 , N'ha99@gmail.com' , N'Hải Dương'  ),
	  (N'Nghiêm Huyền Ngọc' , 0394222222 , N'ngoc98@gmail.com' , N'Hà Nội' ),
	  (N'Lê Quốc Huy' , 0366669888 , N'huy12@gmail.com' , N'Hà Nội'),
	  (N'Phạm Thanh Hải' , 0844249888 , N'hai56@gmail.com' , N'Vĩnh Phúc'  ),
	  (N'Nguyễn Nhật Hùng' , 0854249222 , N'hung00@gmail.com' , N'hà Nội' ),
	  (N'Nguyễn Quang Nhật' , 0844247777 , N'nhat77@gmail.com' , N'Hà Nội'  ),
	  (N'Dương Quang Minh' , 0856668888 , N'minh88@gmail.com' , N'Hà Nội'  ),
	  (N'Nguyễn Minh Hoàng' , 0842229999 , N'hoang99@gmail.com' , N'Hải Dương' )
	  GO

INSERT  [dbo].[LOAIMAY]
values (N'Xách Tay'),
       (N'Mới '),
	   (N'Trung Bình  - 98,99%'),
	   (N'Cũ - 95%  ')
		GO

INSERT  [dbo].[MAYANH]
values  (N'Canon EOS M100',N'm1.jpg' ,N'' ,10000000 ,1),
        (N'Canon EOS M5',N'm2.jpg' ,N'' ,25000000 ,1),
		(N'Canon EOS 6D',N'm3.jpg' ,N'' ,35000000 ,1),
		(N'Canon EOS 1D X Mark',N'm4.jpg' ,N'' ,35000000 ,1),
		(N'Canon EOS M10',N'm5.jpg' ,N'' , 35000000,1),
		(N'Canon EOS M50',N'm6.jpg' ,N'' , 15000000,2),
		(N'Canon EOS 6D Mark',N'm7.jpg' ,N'' ,15000000 ,2),
		(N'Canon EOS M3',N'm8.jpg' ,N'' ,24000000 ,2),
		(N'Canon EOS M6',N'm9.jpg' ,N'' , 50000000,2),
		(N'Canon EOS 5D Mark',N'm10.jpg' ,N'' ,45000000 ,2),
		(N'Canon EOS 1300D',N'm11.jpg' ,N'' ,20000000 ,3),
        (N'Canon EOS 70D',N'm12.jpg' ,N'' , 18000000,3),
		(N'Canon EOS 5D Mark II',N'm13.jpg' ,N'' ,14000000,3),
		(N'Canon EOS 2000D',N'm14.jpg' ,N'' ,16000000 ,3),
		(N'Canon EOS 77D',N'm15.jpg' ,N'' ,15000000 ,3),
		(N'Canon EOS 5DS',N'm16.jpg' ,N'' ,10000000 ,4),
		(N'Canon EOS 3000D',N'm17.jpg' ,N'' ,12000000 ,4),
		(N'Canon EOS 80D',N'm18.jpg' ,N'' , 15000000,4),
		(N'Canon EOS 5DS R',N'm19.jpg' ,N'' ,10000000 ,4),
		(N'Canon EOS 200D',N'm20.jpg' ,N'' , 10000000,4)
go  
----
alter proc SearchSP
 @tenmay nvarchar(100)
 as
 begin
  select *  from [dbo].[MAYANH] where TENMAY LIKE N'%' + @tenmay + '%'
 end

 go

exec SearchSP '6D'
go
alter proc SearchPrice
 @giadau int ,
 @giacuoi int 
 as
 begin
  select *  from [dbo].[MAYANH] 
  where DONGIA >= @giadau AND DONGIA < @giacuoi
 end

 go
 EXEC SearchPrice 10000000 , 15000000