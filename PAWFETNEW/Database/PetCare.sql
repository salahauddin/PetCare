create database PetCare

use petcare

create table Tbl_User(UserID int primary key identity(100,1),
						UserName varchar(50) not null ,
						Phone_No varchar(20),
						UserAddress varchar(100),
						Email varchar(30)not null,
						UserPassword varchar(100)not null)

sp_help tbl_user
select * from  Tbl_User
drop table Tbl_User

---------------------------------------------------------------------------------------------------------

create table Tbl_Pets(PetID int primary key identity(200,1),
					Pet_Category varchar(20),Age varchar(10),
					Pet_Breed varchar(20),Sex varchar(10),
					Height varchar(10),Weights varchar(20),
					Colour varchar(20),
					Pet_Price nvarchar(20),Pet_Image varchar(100))

drop table Tbl_Pets

---------------------------------------------------------------------------------------------------------
create table Tbl_Service(Service_Id int identity(1000,1)primary key,
						Service_Type varchar(50),
						amount numeric, Description varchar(200))
drop table Tbl_Service

---------------------------------------------------------------------------------------------------------
create table Tbl_DayCare(Daycare_id int identity(700,1)primary key,
						UserID int foreign key references tbl_user(userid) ,
						PetCategory varchar(20),
						PetBreed varchar(20),
						Date_Of_Service Date
						,Duration varchar(20),
						Amount_Paid varchar(20),
						Payment_Status varchar(10),
						Service_id int references Tbl_Service(Service_Id))
drop table Tbl_DayCare

---------------------------------------------------------------------------------------------------------
create table Tbl_Adoption(	AdoptionID int identity(400,1) primary key,
							UserID int foreign key references tbl_user(UserID) , 
							PetID int foreign key references tbl_pets(PetId))  

drop table Tbl_Adoption
---------------------------------------------------------------------------------------------------------
create table Tbl_Doctor(DoctorID int identity(800,1)primary key ,
						Doctor_Name varchar(20),
						Phone_No varchar(20),
						Email varchar(20),
						DoctorAddress varchar(30),
						Salary numeric,
						Qualification varchar(20))
drop table Tbl_Doctor
-------------------------------------------------------------------------------------------------------							
create table Tbl_MedicalAssistance(Medical_id int primary key identity(500,1),
									UserID int foreign key references tbl_user(UserID),
									petID varchar(20),
									Problem varchar(70),
									Appointment_Date DateTime,
									DoctorId int foreign key references Tbl_Doctor(doctorid))
drop table Tbl_MedicalAssistance
									

					
----------------------------------------------------------------------------------------------------

create table Tbl_Donation(DonorID int primary key identity(900,1),
							Donor_Name varchar(20) ,
							Donation_Amount varchar(20),
							DonorAddress varchar(30),
							ContactNo varchar(20)) 

drop table Tbl_Donation

-------------------------------------------------------------------------------------------------------

create table Tbl_PetRating(ID int primary key identity(300,1),PetID int references Tbl_Pets(PetID),Rating int)

drop table Tbl_PetRating
