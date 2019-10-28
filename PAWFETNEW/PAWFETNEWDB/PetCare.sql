create database PetCare

use petcare

create table Tbl_User(UserID int primary key identity(100,1),
						UserName varchar(20) not null ,
						Phone_No varchar(20),
						UserAddress varchar(20),
						Email varchar(20)not null,
						UserPassword varchar(20)not null)

						select * from  Tbl_User

create table Tbl_Pets(PetID int primary key identity(200,1),
					Pet_Category varchar(20),Age varchar(10),
					Pet_Breed varchar(20),Sex varchar(10),
					Height varchar(10),Weights varchar(20),
					Colour varchar(20),
					Pet_Price nvarchar(20))

alter table tbl_pets add ImageLocation varchar(100)

create table Tbl_Products(ProductID  int identity(300,1) primary key,
							Product_Name varchar(20),
							Price nvarchar(20),
							Stock nvarchar(10),
							Manufacturer varchar(20),
							Manufacture_Date date)


create table Tbl_purchased_products(Purchase_ID int identity(5000,1) primary key,
									Product_ID int foreign key references Tbl_Products(ProductId),
									UserID int foreign key references Tbl_User(UserID),
									Quantity varchar(20),
									Purchase_Date date)




create table Tbl_Adoption(	AdoptionID int identity(400,1) primary key,
							UserID int foreign key references tbl_user(UserID) , 
							PetID int foreign key references tbl_pets(PetId))  


create table Tbl_Doctor(DoctorID int identity(800,1)primary key ,
						Doctor_Name varchar(20),
						Phone_No varchar(20),
						Email varchar(20),
						DoctorAddress varchar(30),
						Salary numeric,
						Qualification varchar(20))
							
create table Tbl_MedicalAssistance(Medical_id int primary key identity(500,1),
									UserID int foreign key references tbl_user(UserID),
									petID varchar(20),
									Problem varchar(70),
									Appointment_Date DateTime,
									DoctorId int foreign key references Tbl_Doctor(doctorid))
									
									
create table Tbl_Query(Query_ID int identity(1000,1)primary key,
						UserID int foreign key references tbl_user(userid) ON DELETE CASCADE ,
						Question varchar(100),
						Answer varchar(100)) 

create table Tbl_Donation(DonorID int primary key identity(900,1),
							Donor_Name varchar(20) ,
							Donation_Amount varchar(20),
							DonorAddress varchar(30),
							ContactNo varchar(20)) 