USE [AdventureWorksLT2019]

go

/****** Object:  View [dbo].[ProdView]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE VIEW [dbo].[ProdView]
AS
  SELECT productid,
         [product].[name]    
         AS 'product',
         productcategory.[name]
         AS 'category',
         color,
         size,
         [weight],
         listprice,
         productdescription.[description],
         standardcost,
         productnumber,
         sellstartdate,
         sellenddate,
         product.rowguid
  FROM   ((((saleslt.product
           INNER JOIN saleslt.productmodel
                   ON saleslt.product.productmodelid =
                      saleslt.productmodel.productmodelid)
           INNER JOIN saleslt.productcategory
                   ON saleslt.product.productcategoryid =
                      saleslt.productcategory.productcategoryid)
           INNER JOIN saleslt.productmodelproductdescription
                   ON saleslt.productmodel.productmodelid =
                      saleslt.productmodelproductdescription.productmodelid)
           INNER JOIN saleslt.productdescription
                   ON saleslt.productmodelproductdescription.productdescriptionid =
                      saleslt.productdescription.productdescriptionid)
  WHERE  culture = 'en'

go

/****** Object:  StoredProcedure [dbo].[CreateCust]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[CreateCust] @Title        NVARCHAR(8),
                                    @firstName    NVARCHAR(50),
                                    @lastName     NVARCHAR(50),
                                    @middleName   NVARCHAR(50),
                                    @suffix       NVARCHAR(10),
                                    @companyName  NVARCHAR(128),
                                    @salesPerson  NVARCHAR(128),
                                    @emailAddress NVARCHAR(50),
                                    @phone        NVARCHAR(50),
                                    @PasswordHash NVARCHAR(50),
                                    @PasswordSalt NVARCHAR(50),
                                    @modifydate   NVARCHAR(50)
AS
    INSERT INTO saleslt.customer
                (title,
                 firstname,
                 lastname,
                 middlename,
                 suffix,
                 companyname,
                 salesperson,
                 emailaddress,
                 phone,
                 passwordhash,
                 passwordsalt,
                 modifieddate)
    VALUES      (@Title,
                 @Firstname,
                 @lastName,
                 @middleName,
                 @suffix,
                 @companyName,
                 @salesPerson,
                 @emailAddress,
                 @phone,
                 @PasswordHash,
                 @PasswordSalt,
                 @modifydate)

go

/****** Object:  StoredProcedure [dbo].[DelCust]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[DelCust] @custID    INT,
                                 @addressID INT
AS
    DELETE FROM saleslt.customer
    WHERE  customerid = @custID

    DELETE FROM saleslt.customeraddress
    WHERE  customerid = @custID

    DELETE FROM saleslt.[address]
    WHERE  addressid = @addressID

    DELETE FROM saleslt.salesorderheader
    WHERE  customerid = @custID

go

/****** Object:  StoredProcedure [dbo].[GetAddID]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[GetAddID]
AS
    SELECT TOP 1 saleslt.[address].addressid
    FROM   saleslt.[address]
    ORDER  BY addressid DESC

go

/****** Object:  StoredProcedure [dbo].[GetCust]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[GetCust]
AS
    SELECT saleslt.[customer].customerid,
           [title],
           [firstname],
           [middlename],
           [lastname],
           [suffix],
           [companyname],
           [salesperson],
           [emailaddress],
           [phone],
           [passwordhash],
           [passwordsalt],
           saleslt.customeraddress.[addressid],
           [addresstype],
           [addressline1],
           [addressline2],
           [city],
           [stateprovince],
           [countryregion],
           [postalcode],
           saleslt.[customer].[rowguid],
           saleslt.customer.modifieddate
    FROM   (([AdventureWorksLT2019].[SalesLT].[customer]
            LEFT OUTER JOIN saleslt.customeraddress
                         ON saleslt.customer.customerid =
                             saleslt.customeraddress.customerid)
            LEFT OUTER JOIN saleslt.[address]
                         ON saleslt.customeraddress.addressid =
           saleslt.[address].addressid)

go

/****** Object:  StoredProcedure [dbo].[GetCustID]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[GetCustID]
AS
    SELECT TOP 1 saleslt.customer.customerid
    FROM   saleslt.customer
    ORDER  BY customerid DESC

go

/****** Object:  StoredProcedure [dbo].[GetProd]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[GetProd]
AS
    SELECT TOP (1000) [productid],
                      [product],
                      [category],
                      [color],
                      [size],
                      [weight],
                      [listprice],
                      [description],
                      [standardcost],
                      [productnumber],
                      [sellstartdate],
                      [sellenddate],
                      [rowguid]
    FROM   [AdventureWorksLT2019].[dbo].[prodview]

go

/****** Object:  StoredProcedure [dbo].[InsertAdd]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[InsertAdd] @addressLine1  NVARCHAR(60),
                                   @addressLine2  NVARCHAR(60),
                                   @city          NVARCHAR(30),
                                   @stateProvince NVARCHAR(50),
                                   @countryRegion NVARCHAR(50),
                                   @postalCode    NVARCHAR(15),
                                   @ModifiedDate  NVARCHAR(50)
AS
    INSERT INTO saleslt.[address]
                (addressline1,
                 addressline2,
                 city,
                 stateprovince,
                 countryregion,
                 postalcode,
                 modifieddate)
    VALUES      (@addressLine1,
                 @addressLine2,
                 @city,
                 @stateProvince,
                 @countryRegion,
                 @postalCode,
                 @ModifiedDate)

go

/****** Object:  StoredProcedure [dbo].[InsertCustAdd]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[InsertCustAdd] @custID       INT,
                                       @addID        INT,
                                       @addressType  NVARCHAR(50),
                                       @modifiedDate NVARCHAR(50)
AS
    INSERT INTO saleslt.customeraddress
                (customerid,
                 addressid,
                 addresstype,
                 modifieddate)
    VALUES      (@custID,
                 @addID,
                 @addressType,
                 @modifiedDate)

go

/****** Object:  StoredProcedure [dbo].[UpdateAdd]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[UpdateAdd] @addressID     INT,
                                   @addressLine1  NVARCHAR(60),
                                   @addressLine2  NVARCHAR(60),
                                   @city          NVARCHAR(30),
                                   @stateProvince NVARCHAR(50),
                                   @countryRegion NVARCHAR(50),
                                   @postalCode    NVARCHAR(15),
                                   @ModifiedDate  NVARCHAR(50)
AS
    UPDATE saleslt.address
    SET    addressline1 = @addressLine1,
           addressline2 = @addressLine2,
           city = @city,
           stateprovince = @stateProvince,
           countryregion = @countryRegion,
           postalcode = @postalCode,
           modifieddate = @ModifiedDate
    WHERE  addressid = @addressID

go

/****** Object:  StoredProcedure [dbo].[UpdateCust]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[UpdateCust] @custID       INT,
                                    @Title        NVARCHAR(8),
                                    @firstName    NVARCHAR(50),
                                    @lastName     NVARCHAR(50),
                                    @middleName   NVARCHAR(50),
                                    @suffix       NVARCHAR(10),
                                    @companyName  NVARCHAR(128),
                                    @salesPerson  NVARCHAR(128),
                                    @emailAddress NVARCHAR(50),
                                    @phone        NVARCHAR(50),
                                    @PasswordHash NVARCHAR(50),
                                    @PasswordSalt NVARCHAR(50),
                                    @modifydate   NVARCHAR(50)
AS
    UPDATE saleslt.customer
    SET    title = @Title,
           firstname = @firstName,
           lastname = @lastName,
           middlename = @middleName,
           suffix = @suffix,
           companyname = @companyName,
           salesperson = @salesPerson,
           emailaddress = @emailAddress,
           phone = @phone,
           passwordhash = @PasswordHash,
           passwordsalt = @PasswordSalt,
           modifieddate = @modifydate
    WHERE  customerid = @custID

go

/****** Object:  StoredProcedure [dbo].[UpdateCustAdd]    Script Date: 2/17/2021 6:52:59 AM ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[UpdateCustAdd] @customerID   INT,
                                       @addressID    INT,
                                       @addressType  NVARCHAR(50),
                                       @modifiedDate NVARCHAR(50)
AS
    UPDATE saleslt.customeraddress
    SET    addresstype = @addressType,
           modifieddate = @modifiedDate
    WHERE  customerid = @customerID
           AND addressid = @addressID

go 