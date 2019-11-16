/*
SQLyog Community
MySQL - 8.0.18 : Database - ved_soft_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/* Procedure structure for procedure `SP_Get_All_Customers` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_Get_All_Customers`()
BEGIN
    SELECT * FROM CUSTOMER_MASTER;
	

	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_INSERT_CUSTOMER` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_INSERT_CUSTOMER`(
        IN  p_NAME                    VARCHAR(150), 
        IN  p_CODE                    VARCHAR(150)   
         )
BEGIN

    INSERT INTO CUSTOMER_MASTER(CODE ,NAME )VALUES(p_CODE , p_NAME) ; 
	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_INSERT_USER_DETAILS` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_INSERT_USER_DETAILS`(
	
IN	P_USER_ID INT (11),
IN	P_PASSWORD_EXPIRATION_DATE DATETIME ,
IN	P_LANGUAGE_ID INT (11),
IN	P_PAGE_SIZE INT (4),
IN	P_PWD_VALIDATION_CODE VARCHAR (400),
IN	P_IS_TEMPORARYPASSWORD INT (2),
IN	P_LAST_LOGIN_DATE DATE ,
IN	P_LOCK_ATTEMPTS INT (2),
IN	P_CREATED_BY INT (11),
IN	P_CREATED_DATE DATETIME ,
IN	P_MODIFIED_BY INT (11),
IN	P_MODIFIED_DATE DATETIME ,
OUT	P_USER_DETAIL_OUT_ID INT (11)
)
BEGIN
START TRANSACTION;
	   INSERT INTO USER_DETAILS
	   (
	USER_ID ,
	PASSWORD_EXPIRATION_DATE  ,
	LANGUAGE_ID ,
	PAGE_SIZE ,
	PWD_VALIDATION_CODE ,
	IS_TEMPORARYPASSWORD ,
	LAST_LOGIN_DATE  ,
	LOCK_ATTEMPTS ,
	CREATED_BY ,
	CREATED_DATE  ,
	MODIFIED_BY ,
	MODIFIED_DATE 
	   )
	   VALUES(
	P_USER_ID ,
	P_PASSWORD_EXPIRATION_DATE  ,
	P_LANGUAGE_ID ,
	P_PAGE_SIZE,
	P_PWD_VALIDATION_CODE ,
	P_IS_TEMPORARYPASSWORD ,
	P_LAST_LOGIN_DATE  ,
	P_LOCK_ATTEMPTS ,
	P_CREATED_BY ,
	P_CREATED_DATE  ,
	P_MODIFIED_BY ,
	P_MODIFIED_DATE 		   );
   
SET P_USER_DETAIL_OUT_ID= LAST_INSERT_ID(USER_DETAILS) ;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_INSERT_USER_MASTER` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_INSERT_USER_MASTER`(    
  IN P_LOGIN_ID varchar(150) ,
  IN P_PASSWORD varchar(250) ,
  IN P_FIRST_NAME varchar(150) ,
  IN P_MIDDLE_NAME varchar(150) ,
  IN P_LAST_NAME varchar(150) ,
  IN P_USER_TYPE_ID int(11) ,
  IN P_ACTIVE int(1) ,
  IN P_CUSTOMER_ID int(11) ,
  IN P_CONTACT_NO json ,
  IN P_ADDRESS json ,
  IN P_NOTIFICATION_ID varchar(150) ,
  IN P_CREATED_DATE datetime ,
  IN P_CREATED_BY int(11) ,
  IN P_MODIFIED_DATE datetime ,
  IN P_MODIFIED_BY int(11) ,
  OUT P_OUT_USER_ID INT(11) 
  )
BEGIN
	  START TRANSACTION;
	  
		insert into USER_MASTER
		   (		 
		   LOGIN_ID  ,
		   PASSWORD  ,
		   FIRST_NAME  ,
		   MIDDLE_NAME ,
		   LAST_NAME  ,
		   USER_TYPE_ID  ,
		   ACTIVE  ,
		   CUSTOMER_ID  ,
		   CONTACT_NO  ,
		   ADDRESS  ,
		   NOTIFICATION_ID  ,
		   CREATED_DATE  ,
		   CREATED_BY  ,
		   MODIFIED_DATE  ,
		   MODIFIED_BY 
		   )
		   values
		   (
		
		   P_LOGIN_ID  ,
		   P_PASSWORD  ,
		   P_FIRST_NAME  ,
		   P_MIDDLE_NAME ,
		   P_LAST_NAME  ,
		   P_USER_TYPE_ID  ,
		   P_ACTIVE  ,
		   P_CUSTOMER_ID  ,
		   P_CONTACT_NO  ,
		   P_ADDRESS  ,
		   P_NOTIFICATION_ID  ,
		   P_CREATED_DATE  ,
		   P_CREATED_BY  ,
		   P_MODIFIED_DATE  ,
		   P_MODIFIED_BY );
		    #P_ID=last_insert_id(USER_MASTER);
		    SET P_OUT_USER_ID= LAST_INSERT_ID() ;

	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_INSERT_STUDENT` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_INSERT_STUDENT`(
  
IN P_USER_ID int (11),
IN P_ROLL_NO  INT(11),
IN P_GUARDIAN_USER_ID int (11),
IN P_IS_ENROLLED int (11),
IN P_ACTIVE int (11),
IN P_CREATED_BY int (11),
IN P_CREATED_DATE DATETIME ,
IN P_MODIFIED_BY int (11),
IN P_MODIFIED_DATE datetIME,
 OUT P_OUT_STUDENT_ID INT (11)
)
BEGIN
START TRANSACTION;
	   insert into STUDENT
	   (
	  USER_ID ,
	  ROLL_NO,
	 GUARDIAN_USER_ID ,
	 IS_ENROLLED ,
	 ACTIVE ,
	 CREATED_BY ,
	 CREATED_DATE  ,
	 MODIFIED_BY ,
	 MODIFIED_DATE 
	   )
	   VALUES(
	 P_USER_ID ,
	 P_ROLL_NO,
	 P_GUARDIAN_USER_ID ,
	 P_IS_ENROLLED ,
	 P_ACTIVE ,
	 P_CREATED_BY ,
	 P_CREATED_DATE  ,
	 P_MODIFIED_BY ,
	 P_MODIFIED_DATE 
	   );
   
SET P_OUT_STUDENT_ID= last_insert_id() ;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `DEV_TEST` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `DEV_TEST`(IN P_STUDENT_OBJECT JSON,
OUT P_OUT_FLAG VARCHAR(50)    
    )
BEGIN
    DECLARE    J_V_CUSTOMERID VARCHAR(40);    
    DECLARE    J_V_STUDENT_LOGIN VARCHAR(150);
    DECLARE    J_V_STUDENT_LOGIN_PASSWORD VARCHAR(250);
    DECLARE    J_V_STUDENT_ROLLNO INT(11);
    DECLARE    J_V_STUDENT_FIRST_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_MIDDLE_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_LAST_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_NOTIFICATION_ID VARCHAR(150) ;
    DECLARE    J_V_STUDENT_ADDRESS JSON ;
    DECLARE    J_V_STUDENT_CONTACTNO INT(11) ;
    DECLARE    J_V_IS_ENROLLED INT(11);
    DECLARE    J_V_GUARDIAN_LOGIN VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_LOGIN_PASSWORD VARCHAR(250);
    DECLARE    J_V_GUARDIAN_FIRST_NAME VARCHAR(150);
    DECLARE    J_V_GUARDIAN_MIDDLE_NAME VARCHAR(150);
    DECLARE    J_V_GUARDIAN_LAST_NAME VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_NOTIFICATION_ID     VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_ADDRESS JSON ;
    DECLARE    J_V_GUARDIAN_CONTACTNO JSON;
    DECLARE    J_V_FATHER_FIRST_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_MIDDLE_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_LAST_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_OCCUPATION VARCHAR(150) ;
    DECLARE    J_V_FATHER_QUALIFICATION VARCHAR(150) ;
    DECLARE    J_V_FATHER_ANUAL_INCOME DECIMAL ;
    DECLARE    J_V_FATHER_NOTIFICATION_ID     VARCHAR(150) ;
    DECLARE    J_V_FATHER_ADDRESS JSON;
    DECLARE    J_V_FATHER_CONTACTNO INT ;
    DECLARE    J_V_MOTHER_FIRST_NAME VARCHAR(150) ;
    DECLARE    J_V_MOTHER_MIDDLE_NAME VARCHAR(150) ;
    DECLARE    J_V_MOTHER_LAST_NAME VARCHAR(150);
    DECLARE    J_V_MOTHER_OCCUPATION VARCHAR(150) ;
    DECLARE    J_V_MOTHER_QUALIFICATION VARCHAR(150) ;
    DECLARE    J_V_STUDENT_GENDER VARCHAR(2) ;
    DECLARE    J_V_STUDENT_IMAGE_PATH VARCHAR(150) ;
    DECLARE    J_V_MOTHER_ANUAL_INCOME DECIMAL ;
    DECLARE    J_V_MOTHER_NOTIFICATION_ID  VARCHAR(150)  ;
    DECLARE    J_V_MOTHER_ADDRESS JSON  ;
    DECLARE    J_V_MOTHER_CONTACTNO INT;
    DECLARE    J_V_CREATED_BY INT(11);
    DECLARE    J_V_CREATED_DATE DATETIME ;
    DECLARE   J_V_STUDENT_ACADEMIC_INSTITUTE VARCHAR(150);
    DECLARE   J_V_STUDENT_DATE_OF_BIRTH DATETIME;
    DECLARE   J_V_STUDENT_QUALIFICATION VARCHAR(150);
    #Internal Varialbles 
    DECLARE    V_MODIFIED_BY INT(11) ;
    DECLARE    V_MODIFIED_DATE DATETIME ;
    DECLARE    V_ACTIVE INT(11);
    DECLARE    V_USERTYPEID_FOR_STUDENT INT(11);
    DECLARE    V_USERTYPEID_FOR_GUARDIAN INT(11);
    #OUTPUT ID Variables
    DECLARE    V_USER_ID_FOR_STUDENT INT(11);
    DECLARE    V_USER_ID_FOR_GUARDIAN INT(11);
    DECLARE    V_OUT_USER_ID INT(11);
    DECLARE    V_STUDENT_ID INT(11);
    DECLARE    V_STUDENT_DETAIL_ID INT(11);

		SELECT  CUSTOMERID,
		        STUDENT_LOGIN ,
		        STUDENT_ROLLNO,
		        STUDENT_LOGIN_PASSWORD,
			STUDENT_FIRST_NAME ,
			STUDENT_MIDDLE_NAME ,
			STUDENT_LAST_NAME ,
			STUDENT_NOTIFICATION_ID ,
			STUDENT_ADDRESS ,
			STUDENT_CONTACTNO ,
			STUDENT_ACADEMIC_INSTITUTE,
			STUDENT_QUALIFICATION,
			STUDENT_DATE_OF_BIRTH,
			STUDENT_GENDER,
			STUDENT_IMAGE_PATH,
			IS_ENROLLED ,
			GUARDIAN_LOGIN ,
			GUARDIAN_LOGIN_PASSWORD,
			GUARDIAN_FIRST_NAME ,
			GUARDIAN_MIDDLE_NAME ,
			GUARDIAN_LAST_NAME ,
			GUARDIAN_NOTIFICATION_ID ,
			GUARDIAN_ADDRESS ,
			GUARDIAN_CONTACTNO ,
			FATHER_FIRST_NAME ,
			FATHER_MIDDLE_NAME ,
			FATHER_LAST_NAME ,
			FATHER_OCCUPATION ,
			FATHER_QUALIFICATION,
			FATHER_ANUAL_INCOME,
			FATHER_NOTIFICATION_ID ,
			FATHER_ADDRESS ,
			FATHER_CONTACTNO ,
			MOTHER_FIRST_NAME ,
			MOTHER_MIDDLE_NAME ,
			MOTHER_LAST_NAME ,
			MOTHER_OCCUPATION ,
			MOTHER_QUALIFICATION,
			MOTHER_ANUAL_INCOME ,
			MOTHER_NOTIFICATION_ID  ,
			MOTHER_ADDRESS ,
			MOTHER_CONTACTNO ,
			CREATED_BY,
			CREATED_DATE
			INTO 
			J_V_CUSTOMERID,
			J_V_STUDENT_LOGIN ,
			J_V_STUDENT_ROLLNO,
			J_V_STUDENT_LOGIN_PASSWORD,
			J_V_STUDENT_FIRST_NAME ,
			J_V_STUDENT_MIDDLE_NAME ,
			J_V_STUDENT_LAST_NAME ,
			J_V_STUDENT_NOTIFICATION_ID ,
			J_V_STUDENT_ADDRESS ,
			J_V_STUDENT_CONTACTNO ,
			J_V_STUDENT_ACADEMIC_INSTITUTE,
			J_V_STUDENT_QUALIFICATION,
			J_V_STUDENT_DATE_OF_BIRTH,
			J_V_STUDENT_GENDER,
			J_V_STUDENT_IMAGE_PATH,
			J_V_IS_ENROLLED ,
			J_V_GUARDIAN_LOGIN ,
			J_V_GUARDIAN_LOGIN_PASSWORD,
			J_V_GUARDIAN_FIRST_NAME ,
			J_V_GUARDIAN_MIDDLE_NAME ,
			J_V_GUARDIAN_LAST_NAME ,
			J_V_GUARDIAN_NOTIFICATION_ID ,
			J_V_GUARDIAN_ADDRESS ,
			J_V_GUARDIAN_CONTACTNO ,
			J_V_FATHER_FIRST_NAME ,
			J_V_FATHER_MIDDLE_NAME ,
			J_V_FATHER_LAST_NAME ,
			J_V_FATHER_OCCUPATION ,
			J_V_FATHER_QUALIFICATION,
			J_V_FATHER_ANUAL_INCOME,
			J_V_FATHER_NOTIFICATION_ID ,
			J_V_FATHER_ADDRESS ,
			J_V_FATHER_CONTACTNO ,
			J_V_MOTHER_FIRST_NAME ,
			J_V_MOTHER_MIDDLE_NAME ,
			J_V_MOTHER_LAST_NAME ,
			J_V_MOTHER_OCCUPATION ,
			J_V_MOTHER_QUALIFICATION,
			J_V_MOTHER_ANUAL_INCOME ,
			J_V_MOTHER_NOTIFICATION_ID  ,
			J_V_MOTHER_ADDRESS ,
			J_V_MOTHER_CONTACTNO  ,
			J_V_CREATED_BY,
			J_V_CREATED_DATE
			FROM
		 JSON_TABLE('{
		"Customerid": "1",
		"Studentloginid": "Dev16nov19",
		               "Rollno": "12",
		               "Studentloginpassword": "abc",
		               "Studentfirstname": "Dev",
				"Studentmiddlename": "kumt",
				"Studentlastname": "Tanwar",
				"Studentnotificationid": "dev.sanga@gmail.com",
				"Studentaddress": "{}",
				"Studentcontactno": "",
				"Studentacademicinstitute": "",
				"StudentQualification": "",
				"Studentdateofbirth": "",
				"Gender": "M",
				"Studentimagepath": "",
				"Isenrolled": "0",
				"Guardianloginid": "DWARKA123",
				"Guardianpassword": "abc",
				"Guardianfirstname": "DWARKA",
				"Guardianmiddlename": "",
				"Guardianlastname": "TANWAR",
				"Guardiannotificationid": "32",
				"Guardianaddress": "{}",
				"Guardiancontactno": "",
				"Fatherfirstname": "DWARKA",
				"Fathermiddlename": "",
				"Fatherlastname": "TANWAR",
				"Fathernotificationid": "dev.sanga@gmail.com",
				"Fathercontactno": "",
				"FatherQualification": "BCA",
				"FatherOccupation": "RETD",
				"FatherAnualIncome": "2345",
				"Fatheraddress": "{}",
				"Motherfirstname": "SHOBHA",
				"Mothermiddlename": "",
				"Motherlastname": "TANWAR",
				"Mothernotificationid": "32",
				"Mothercontactno": "dev.sanga@gmail.com",
				"MotherQualification": "",
				"MotherOccupation": "",
				"MotherAnualIncome": "98765432",
				"Createddate": "",
				"Createdby": "1"
				
			  }', 
			  '$' COLUMNS (
            CUSTOMERID INT(11) PATH '$.Customerid' ,
	    STUDENT_LOGIN VARCHAR(150)  PATH '$.Studentloginid',
	    STUDENT_ROLLNO INT(11) PATH '$.Rollno' ,
	    STUDENT_LOGIN_PASSWORD VARCHAR(250)  PATH '$.Studentloginpassword',
            STUDENT_FIRST_NAME VARCHAR(150) PATH '$.Studentfirstname',
            STUDENT_MIDDLE_NAME VARCHAR(150) PATH '$.Studentmiddlename',
            STUDENT_LAST_NAME VARCHAR(150) PATH '$.Studentlastname', 
            STUDENT_NOTIFICATION_ID VARCHAR(150) PATH '$.Studentnotificationid', 
            STUDENT_ADDRESS JSON PATH '$.Studentaddress' ,
            STUDENT_CONTACTNO INT(11) PATH '$.Studentcontactno' ,
            STUDENT_ACADEMIC_INSTITUTE VARCHAR(150) PATH '$.Studentacademicinstitute', 
            STUDENT_QUALIFICATION VARCHAR(150) PATH '$.StudentQualification', 
            STUDENT_DATE_OF_BIRTH DATETIME PATH '$.Studentdateofbirth', 
            STUDENT_GENDER VARCHAR(2) PATH '$.Gender', 
            STUDENT_IMAGE_PATH VARCHAR(2) PATH '$.Studentimagepath', 
            IS_ENROLLED INT(11) PATH '$.Isenrolled' ,
            GUARDIAN_LOGIN VARCHAR(150)  PATH '$.Guardianloginid',
            GUARDIAN_LOGIN_PASSWORD VARCHAR(250)  PATH '$.Guardianloginpassword',
            GUARDIAN_FIRST_NAME VARCHAR(150) PATH '$.Guardianfirstname',
            GUARDIAN_MIDDLE_NAME VARCHAR(150) PATH '$.Guardianmiddlename',
            GUARDIAN_LAST_NAME VARCHAR(150) PATH '$.Guardianlastname',
            GUARDIAN_NOTIFICATION_ID     VARCHAR(150) PATH '$.Guardiannotificationid',
            GUARDIAN_ADDRESS JSON PATH '$.Guardianaddress' ,
            GUARDIAN_CONTACTNO JSON PATH '$.Guardiancontactno' ,
            FATHER_FIRST_NAME VARCHAR(150) PATH '$.Fatherfirstname',
            FATHER_MIDDLE_NAME VARCHAR(150) PATH '$.Fathermiddlename',
            FATHER_LAST_NAME VARCHAR(150) PATH '$.Fatherlastname',
            FATHER_OCCUPATION VARCHAR(150) PATH '$.FatherOccupation',
            FATHER_QUALIFICATION VARCHAR(150) PATH '$.FatherQualification',
            FATHER_ANUAL_INCOME DECIMAL PATH '$.FatherAnualIncome',
            FATHER_NOTIFICATION_ID     VARCHAR(150) PATH '$.Fathernotificationid',
            FATHER_ADDRESS JSON PATH '$.Fatheraddress' ,
            FATHER_CONTACTNO INT PATH '$.Fathercontactno' ,
            MOTHER_FIRST_NAME VARCHAR(150) PATH '$.Motherfirstname',
            MOTHER_MIDDLE_NAME VARCHAR(150) PATH '$.Mothermiddlename',
            MOTHER_LAST_NAME VARCHAR(150) PATH '$.Motherlastname',
            MOTHER_OCCUPATION VARCHAR(150) PATH '$.MotherOccupation',
            MOTHER_QUALIFICATION VARCHAR(150) PATH '$.MotherQualification',
            MOTHER_ANUAL_INCOME DECIMAL PATH '$.MotherAnualIncome',
            MOTHER_NOTIFICATION_ID     VARCHAR(150) PATH '$.Mothernotificationid',
            MOTHER_ADDRESS JSON PATH '$.Motheraddress' ,
            MOTHER_CONTACTNO INT PATH '$.Mothercontactno' ,
            CREATED_BY INT PATH '$.Createdby' ,
            CREATED_DATE DATETIME PATH '$.Createddate' 
							
						   )
				 ) STUDENT_DETAILS;
START TRANSACTION;
SET V_ACTIVE=1;
SET V_USERTYPEID_FOR_STUDENT=3;
SET V_USERTYPEID_FOR_GUARDIAN=4;
SET V_USER_ID_FOR_STUDENT=0; 
SET V_USER_ID_FOR_GUARDIAN  =0;
SET V_STUDENT_ID=0;
SET V_STUDENT_DETAIL_ID=0;
    #First Student is exits or not if not exists then create user first
	
        SELECT IFNULL(ID,0)  INTO V_USER_ID_FOR_STUDENT
        FROM USER_MASTER WHERE customer_id=J_V_CUSTOMERID AND LOGIN_ID=J_V_STUDENT_LOGIN;	
	
	IF V_USER_ID_FOR_STUDENT =0 THEN
		CALL SP_INSERT_USER_MASTER(        J_V_STUDENT_LOGIN 	,
                                           J_V_STUDENT_LOGIN_PASSWORD	,
                                           J_V_STUDENT_FIRST_NAME,
                                           J_V_STUDENT_MIDDLE_NAME 	,
                                           J_V_STUDENT_LAST_NAME 	,
			                    		   V_USERTYPEID_FOR_STUDENT	,
                                           V_ACTIVE	,
                                           J_V_CUSTOMERID	,
                                           J_V_STUDENT_CONTACTNO 	,
                                           J_V_STUDENT_ADDRESS 	,
                                           J_V_STUDENT_NOTIFICATION_ID 	,
                                           J_V_CREATED_DATE	,
                                           J_V_CREATED_BY	,
                                           V_MODIFIED_DATE	,
                                           V_MODIFIED_BY	,
                                           @V_USER_ID_FOR_STUDENT
									);
	END IF;
	
	
	#First Guardian is exists or not if not exists then create user first
	
	
	SELECT IFNULL(ID,0)  INTO V_USER_ID_FOR_GUARDIAN
        FROM USER_MASTER WHERE customer_id=J_V_CUSTOMERID AND LOGIN_ID=J_V_GUARDIAN_LOGIN;	
		IF V_USER_ID_FOR_GUARDIAN =0 THEN
				CALL SP_INSERT_USER_MASTER(J_V_GUARDIAN_LOGIN 	,
                                          J_V_GUARDIAN_LOGIN_PASSWORD	,
                                          J_V_GUARDIAN_FIRST_NAME,
                                          J_V_GUARDIAN_MIDDLE_NAME 	,
                                          J_V_GUARDIAN_LAST_NAME 	,
					  V_USERTYPEID_FOR_GUARDIAN	,
                                          V_ACTIVE	,
                                          J_V_CUSTOMERID	,
                                          J_V_GUARDIAN_CONTACTNO 	,
                                          J_V_GUARDIAN_ADDRESS 	,
                                          J_V_GUARDIAN_NOTIFICATION_ID 	,
                                          J_V_CREATED_DATE	,
                                          J_V_CREATED_BY	,
                                          V_MODIFIED_DATE	,
                                          V_MODIFIED_BY	,
                                          @V_USER_ID_FOR_GUARDIAN);
		END IF;
		
		
		#Check whether Student exists or not 
		SELECT IFNULL(ID,0)  INTO V_STUDENT_ID
        FROM STUDENT WHERE USER_ID=V_USER_ID_FOR_STUDENT ;	
		
		IF V_STUDENT_ID=0 then 
	
		CALL SP_INSERT_STUDENT
					(
			  
			V_USER_ID_FOR_STUDENT,
			J_V_STUDENT_ROLLNO,
			V_USER_ID_FOR_GUARDIAN,
			J_V_IS_ENROLLED,
			V_ACTIVE,
			J_V_CREATED_BY,
			J_V_CREATED_DATE ,
			V_MODIFIED_BY,
			V_MODIFIED_DATE,
			@V_STUDENT_ID
			);
	    END IF;	
 
		#Check whether Student exists or not 
		SELECT IFNULL(ID,0)  INTO V_STUDENT_DETAIL_ID
        FROM STUDENT_DETAILS WHERE STUDENT_ID=V_STUDENT_ID ;
 
     IF   	V_STUDENT_DETAIL_ID=0 THEN	
		CALL SP_INSERT_STUDENT_DETAILS(
		V_STUDENT_ID,
		J_V_STUDENT_ACADEMIC_INSTITUTE,
		J_V_STUDENT_IMAGE_PATH,
		J_V_FATHER_FIRST_NAME,
		J_V_FATHER_LAST_NAME,
		J_V_FATHER_CONTACTNO,
		J_V_FATHER_ANUAL_INCOME,
		J_V_FATHER_QUALIFICATION,
		J_V_FATHER_OCCUPATION,
		J_V_MOTHER_FIRST_NAME,
		J_V_MOTHER_LAST_NAME,
		J_V_MOTHER_QUALIFICATION,
		J_V_MOTHER_OCCUPATION,
		J_V_MOTHER_CONTACTNO,
		J_V_MOTHER_ANUAL_INCOME,
		J_V_STUDENT_DATE_OF_BIRTH ,
		J_V_STUDENT_QUALIFICATION,
		J_V_CREATED_BY,
		J_V_CREATED_DATE,
		V_MODIFIED_BY,
		V_MODIFIED_DATE ,
		@V_STUDENT_DETAIL_ID);

    END IF;
          COMMIT;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_INSERT_STUDENT_DETAILS` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_INSERT_STUDENT_DETAILS`(
in	P_STUDENT_ID int (11),
IN	P_STUDENT_ACADEMIC_INSTITUE VARCHAR(150),
IN	P_STUDENT_IMAGE_PATH VARCHAR(150),
IN	P_FATHER_FIRST_NAME varchar (150),
IN	P_FATHER_LAST_NAME varchar (150),
IN	P_FATHER_CONTACTNO int (11),
IN      P_FATHER_ANUAL_INCOME DECIMAL,
IN	P_FATHER_QUALIFICATION varchar (150),
IN	P_FATHER_OCCUPATION varchar (150),
IN	P_MOTHER_FIRST_NAME varchar (150),
IN	P_MOTHER_LAST_NAME varchar (150),
IN	P_MOTHER_QUALIFICATION varchar (150),
IN	P_MOTHER_OCCUPATION varchar (150),
IN	P_MOTHER_CONTACTNO int (11),
IN      P_MOTHER_ANUAL_INCOME DECIMAL,
IN	P_DATE_OF_BIRTH dateTIME ,
IN	P_QUALIFICATION varchar (150),
IN	P_CREATED_BY int (11),
IN	P_CREATED_DATE DATETIME ,
IN	P_MODIFIED_BY int (11),
IN	P_MODIFIED_DATE DATETIME ,
OUT	P_OUT_STUDENT_DETAIL_ID INT (11)
)
BEGIN
START TRANSACTION;
	   INSERT INTO STUDENT_DETAILS
	   (
	STUDENT_ID ,
	STUDENT_ACADEMIC_INSTITUE,
	STUDENT_IMAGE_PATH,
	FATHER_FIRST_NAME ,
	FATHER_LAST_NAME ,
	FATHER_CONTACTNO ,
	FATHER_ANUAL_INCOME,
	FATHER_QUALIFICATION ,
	FATHER_OCCUPATION,
	MOTHER_FIRST_NAME,
	MOTHER_LAST_NAME,
	MOTHER_QUALIFICATION,
	MOTHER_OCCUPATION ,
	MOTHER_CONTACTNO ,
	MOTHER_ANUAL_INCOME,
	DATE_OF_BIRTH  ,
	QUALIFICATION,
	CREATED_BY ,
	CREATED_DATE  ,
	MODIFIED_BY ,
	MODIFIED_DATE 
	   )
	   VALUES(
	P_STUDENT_ID ,
P_STUDENT_ACADEMIC_INSTITUE ,
P_STUDENT_IMAGE_PATH,
	P_FATHER_FIRST_NAME ,
	P_FATHER_LAST_NAME ,
	P_FATHER_CONTACTNO ,
	P_FATHER_ANUAL_INCOME,
	P_FATHER_QUALIFICATION ,
	P_FATHER_OCCUPATION,
	P_MOTHER_FIRST_NAME,
	P_MOTHER_LAST_NAME,
	P_MOTHER_QUALIFICATION,
	P_MOTHER_OCCUPATION ,
	P_MOTHER_CONTACTNO ,
	P_MOTHER_ANUAL_INCOME,
	P_DATE_OF_BIRTH  ,
	P_QUALIFICATION,
	P_CREATED_BY ,
	P_CREATED_DATE  ,
	P_MODIFIED_BY ,
	P_MODIFIED_DATE  );
   
SET P_OUT_STUDENT_DETAIL_ID= LAST_INSERT_ID() ;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `SP_CREATE_STUDENT` */

DELIMITER $$

/*!50003 CREATE PROCEDURE `SP_CREATE_STUDENT`(IN P_STUDENT_OBJECT JSON,
OUT P_OUT_FLAG VARCHAR(50)    
    )
BEGIN
    DECLARE    J_V_CUSTOMERID VARCHAR(40);    
    DECLARE    J_V_STUDENT_LOGIN VARCHAR(150);
    DECLARE    J_V_STUDENT_LOGIN_PASSWORD VARCHAR(250);
    DECLARE    J_V_STUDENT_ROLLNO INT(11);
    DECLARE    J_V_STUDENT_FIRST_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_MIDDLE_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_LAST_NAME VARCHAR(150);
    DECLARE    J_V_STUDENT_NOTIFICATION_ID VARCHAR(150) ;
    DECLARE    J_V_STUDENT_ADDRESS JSON ;
    DECLARE    J_V_STUDENT_CONTACTNO INT(11) ;
    DECLARE    J_V_IS_ENROLLED INT(11);
    DECLARE    J_V_GUARDIAN_LOGIN VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_LOGIN_PASSWORD VARCHAR(250);
    DECLARE    J_V_GUARDIAN_FIRST_NAME VARCHAR(150);
    DECLARE    J_V_GUARDIAN_MIDDLE_NAME VARCHAR(150);
    DECLARE    J_V_GUARDIAN_LAST_NAME VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_NOTIFICATION_ID     VARCHAR(150) ;
    DECLARE    J_V_GUARDIAN_ADDRESS JSON ;
    DECLARE    J_V_GUARDIAN_CONTACTNO JSON;
    DECLARE    J_V_FATHER_FIRST_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_MIDDLE_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_LAST_NAME VARCHAR(150) ;
    DECLARE    J_V_FATHER_OCCUPATION VARCHAR(150) ;
    DECLARE    J_V_FATHER_QUALIFICATION VARCHAR(150) ;
    DECLARE    J_V_FATHER_ANUAL_INCOME DECIMAL ;
    DECLARE    J_V_FATHER_NOTIFICATION_ID     VARCHAR(150) ;
    DECLARE    J_V_FATHER_ADDRESS JSON;
    DECLARE    J_V_FATHER_CONTACTNO INT ;
    DECLARE    J_V_MOTHER_FIRST_NAME VARCHAR(150) ;
    DECLARE    J_V_MOTHER_MIDDLE_NAME VARCHAR(150) ;
    DECLARE    J_V_MOTHER_LAST_NAME VARCHAR(150);
    DECLARE    J_V_MOTHER_OCCUPATION VARCHAR(150) ;
    DECLARE    J_V_MOTHER_QUALIFICATION VARCHAR(150) ;
    DECLARE    J_V_STUDENT_GENDER VARCHAR(2) ;
    DECLARE    J_V_STUDENT_IMAGE_PATH VARCHAR(150) ;
    DECLARE    J_V_MOTHER_ANUAL_INCOME DECIMAL ;
    DECLARE    J_V_MOTHER_NOTIFICATION_ID  VARCHAR(150)  ;
    DECLARE    J_V_MOTHER_ADDRESS JSON  ;
    DECLARE    J_V_MOTHER_CONTACTNO INT;
    DECLARE    J_V_CREATED_BY INT(11);
    DECLARE    J_V_CREATED_DATE DATETIME ;
    DECLARE   J_V_STUDENT_ACADEMIC_INSTITUTE VARCHAR(150);
    DECLARE   J_V_STUDENT_DATE_OF_BIRTH DATETIME;
    DECLARE   J_V_STUDENT_QUALIFICATION VARCHAR(150);
    #Internal Varialbles 
    DECLARE    V_MODIFIED_BY INT(11) ;
    DECLARE    V_MODIFIED_DATE DATETIME ;
    DECLARE    V_ACTIVE INT(11);
    DECLARE    V_USERTYPEID_FOR_STUDENT INT(11);
    DECLARE    V_USERTYPEID_FOR_GUARDIAN INT(11);
    #OUTPUT ID Variables
    DECLARE    V_USER_ID_FOR_STUDENT INT(11);
    DECLARE    V_USER_ID_FOR_GUARDIAN INT(11);
    DECLARE    V_OUT_USER_ID INT(11);
    DECLARE    V_STUDENT_ID INT(11);
    DECLARE    V_STUDENT_DETAIL_ID INT(11);

		SELECT  CUSTOMERID,
		        STUDENT_LOGIN ,
		        STUDENT_ROLLNO,
		        STUDENT_LOGIN_PASSWORD,
			STUDENT_FIRST_NAME ,
			STUDENT_MIDDLE_NAME ,
			STUDENT_LAST_NAME ,
			STUDENT_NOTIFICATION_ID ,
			STUDENT_ADDRESS ,
			STUDENT_CONTACTNO ,
			STUDENT_ACADEMIC_INSTITUTE,
			STUDENT_QUALIFICATION,
			STUDENT_DATE_OF_BIRTH,
			STUDENT_GENDER,
			STUDENT_IMAGE_PATH,
			IS_ENROLLED ,
			GUARDIAN_LOGIN ,
			GUARDIAN_LOGIN_PASSWORD,
			GUARDIAN_FIRST_NAME ,
			GUARDIAN_MIDDLE_NAME ,
			GUARDIAN_LAST_NAME ,
			GUARDIAN_NOTIFICATION_ID ,
			GUARDIAN_ADDRESS ,
			GUARDIAN_CONTACTNO ,
			FATHER_FIRST_NAME ,
			FATHER_MIDDLE_NAME ,
			FATHER_LAST_NAME ,
			FATHER_OCCUPATION ,
			FATHER_QUALIFICATION,
			FATHER_ANUAL_INCOME,
			FATHER_NOTIFICATION_ID ,
			FATHER_ADDRESS ,
			FATHER_CONTACTNO ,
			MOTHER_FIRST_NAME ,
			MOTHER_MIDDLE_NAME ,
			MOTHER_LAST_NAME ,
			MOTHER_OCCUPATION ,
			MOTHER_QUALIFICATION,
			MOTHER_ANUAL_INCOME ,
			MOTHER_NOTIFICATION_ID  ,
			MOTHER_ADDRESS ,
			MOTHER_CONTACTNO ,
			CREATED_BY,
			CREATED_DATE
			INTO 
			J_V_CUSTOMERID,
			J_V_STUDENT_LOGIN ,
			J_V_STUDENT_ROLLNO,
			J_V_STUDENT_LOGIN_PASSWORD,
			J_V_STUDENT_FIRST_NAME ,
			J_V_STUDENT_MIDDLE_NAME ,
			J_V_STUDENT_LAST_NAME ,
			J_V_STUDENT_NOTIFICATION_ID ,
			J_V_STUDENT_ADDRESS ,
			J_V_STUDENT_CONTACTNO ,
			J_V_STUDENT_ACADEMIC_INSTITUTE,
			J_V_STUDENT_QUALIFICATION,
			J_V_STUDENT_DATE_OF_BIRTH,
			J_V_STUDENT_GENDER,
			J_V_STUDENT_IMAGE_PATH,
			J_V_IS_ENROLLED ,
			J_V_GUARDIAN_LOGIN ,
			J_V_GUARDIAN_LOGIN_PASSWORD,
			J_V_GUARDIAN_FIRST_NAME ,
			J_V_GUARDIAN_MIDDLE_NAME ,
			J_V_GUARDIAN_LAST_NAME ,
			J_V_GUARDIAN_NOTIFICATION_ID ,
			J_V_GUARDIAN_ADDRESS ,
			J_V_GUARDIAN_CONTACTNO ,
			J_V_FATHER_FIRST_NAME ,
			J_V_FATHER_MIDDLE_NAME ,
			J_V_FATHER_LAST_NAME ,
			J_V_FATHER_OCCUPATION ,
			J_V_FATHER_QUALIFICATION,
			J_V_FATHER_ANUAL_INCOME,
			J_V_FATHER_NOTIFICATION_ID ,
			J_V_FATHER_ADDRESS ,
			J_V_FATHER_CONTACTNO ,
			J_V_MOTHER_FIRST_NAME ,
			J_V_MOTHER_MIDDLE_NAME ,
			J_V_MOTHER_LAST_NAME ,
			J_V_MOTHER_OCCUPATION ,
			J_V_MOTHER_QUALIFICATION,
			J_V_MOTHER_ANUAL_INCOME ,
			J_V_MOTHER_NOTIFICATION_ID  ,
			J_V_MOTHER_ADDRESS ,
			J_V_MOTHER_CONTACTNO  ,
			J_V_CREATED_BY,
			J_V_CREATED_DATE
			FROM
		 JSON_TABLE(P_STUDENT_OBJECT, 
			  '$' COLUMNS (
            CUSTOMERID INT(11) PATH '$.Customerid' ,
	    STUDENT_LOGIN VARCHAR(150)  PATH '$.Studentloginid',
	    STUDENT_ROLLNO INT(11) PATH '$.Rollno' ,
	    STUDENT_LOGIN_PASSWORD VARCHAR(250)  PATH '$.Studentloginpassword',
            STUDENT_FIRST_NAME VARCHAR(150) PATH '$.Studentfirstname',
            STUDENT_MIDDLE_NAME VARCHAR(150) PATH '$.Studentmiddlename',
            STUDENT_LAST_NAME VARCHAR(150) PATH '$.Studentlastname', 
            STUDENT_NOTIFICATION_ID VARCHAR(150) PATH '$.Studentnotificationid', 
            STUDENT_ADDRESS JSON PATH '$.Studentaddress' ,
            STUDENT_CONTACTNO INT(11) PATH '$.Studentcontactno' ,
            STUDENT_ACADEMIC_INSTITUTE VARCHAR(150) PATH '$.Studentacademicinstitute', 
            STUDENT_QUALIFICATION VARCHAR(150) PATH '$.StudentQualification', 
            STUDENT_DATE_OF_BIRTH DATETIME PATH '$.Studentdateofbirth', 
            STUDENT_GENDER VARCHAR(2) PATH '$.Gender', 
            STUDENT_IMAGE_PATH VARCHAR(2) PATH '$.Studentimagepath', 
            IS_ENROLLED INT(11) PATH '$.Isenrolled' ,
            GUARDIAN_LOGIN VARCHAR(150)  PATH '$.Guardianloginid',
            GUARDIAN_LOGIN_PASSWORD VARCHAR(250)  PATH '$.Guardianloginpassword',
            GUARDIAN_FIRST_NAME VARCHAR(150) PATH '$.Guardianfirstname',
            GUARDIAN_MIDDLE_NAME VARCHAR(150) PATH '$.Guardianmiddlename',
            GUARDIAN_LAST_NAME VARCHAR(150) PATH '$.Guardianlastname',
            GUARDIAN_NOTIFICATION_ID     VARCHAR(150) PATH '$.Guardiannotificationid',
            GUARDIAN_ADDRESS JSON PATH '$.Guardianaddress' ,
            GUARDIAN_CONTACTNO JSON PATH '$.Guardiancontactno' ,
            FATHER_FIRST_NAME VARCHAR(150) PATH '$.Fatherfirstname',
            FATHER_MIDDLE_NAME VARCHAR(150) PATH '$.Fathermiddlename',
            FATHER_LAST_NAME VARCHAR(150) PATH '$.Fatherlastname',
            FATHER_OCCUPATION VARCHAR(150) PATH '$.FatherOccupation',
            FATHER_QUALIFICATION VARCHAR(150) PATH '$.FatherQualification',
            FATHER_ANUAL_INCOME DECIMAL PATH '$.FatherAnualIncome',
            FATHER_NOTIFICATION_ID     VARCHAR(150) PATH '$.Fathernotificationid',
            FATHER_ADDRESS JSON PATH '$.Fatheraddress' ,
            FATHER_CONTACTNO INT PATH '$.Fathercontactno' ,
            MOTHER_FIRST_NAME VARCHAR(150) PATH '$.Motherfirstname',
            MOTHER_MIDDLE_NAME VARCHAR(150) PATH '$.Mothermiddlename',
            MOTHER_LAST_NAME VARCHAR(150) PATH '$.Motherlastname',
            MOTHER_OCCUPATION VARCHAR(150) PATH '$.MotherOccupation',
            MOTHER_QUALIFICATION VARCHAR(150) PATH '$.MotherQualification',
            MOTHER_ANUAL_INCOME DECIMAL PATH '$.MotherAnualIncome',
            MOTHER_NOTIFICATION_ID     VARCHAR(150) PATH '$.Mothernotificationid',
            MOTHER_ADDRESS JSON PATH '$.Motheraddress' ,
            MOTHER_CONTACTNO INT PATH '$.Mothercontactno' ,
            CREATED_BY INT PATH '$.Createdby' ,
            CREATED_DATE DATETIME PATH '$.Createddate' 
							
						   )
				 ) STUDENT_DETAILS;
START TRANSACTION;
SET V_ACTIVE=1;
SET V_USERTYPEID_FOR_STUDENT=3;
SET V_USERTYPEID_FOR_GUARDIAN=4;
SET V_USER_ID_FOR_STUDENT=0; 
SET V_USER_ID_FOR_GUARDIAN  =0;
SET V_STUDENT_ID=0;
SET V_STUDENT_DETAIL_ID=0;
    #First Student is exits or not if not exists then create user first
	
        SELECT IFNULL(ID,0)  INTO V_USER_ID_FOR_STUDENT
        FROM USER_MASTER WHERE customer_id=J_V_CUSTOMERID AND LOGIN_ID=J_V_STUDENT_LOGIN;	
	
	IF V_USER_ID_FOR_STUDENT =0 THEN
		CALL SP_INSERT_USER_MASTER(        J_V_STUDENT_LOGIN 	,
                                           J_V_STUDENT_LOGIN_PASSWORD	,
                                           J_V_STUDENT_FIRST_NAME,
                                           J_V_STUDENT_MIDDLE_NAME 	,
                                           J_V_STUDENT_LAST_NAME 	,
			                    		   V_USERTYPEID_FOR_STUDENT	,
                                           V_ACTIVE	,
                                           J_V_CUSTOMERID	,
                                           J_V_STUDENT_CONTACTNO 	,
                                           J_V_STUDENT_ADDRESS 	,
                                           J_V_STUDENT_NOTIFICATION_ID 	,
                                           J_V_CREATED_DATE	,
                                           J_V_CREATED_BY	,
                                           V_MODIFIED_DATE	,
                                           V_MODIFIED_BY	,
                                           @V_USER_ID_FOR_STUDENT
									);
	END IF;
	
	
	#First Guardian is exists or not if not exists then create user first
	
	
	SELECT IFNULL(ID,0)  INTO V_USER_ID_FOR_GUARDIAN
        FROM USER_MASTER WHERE customer_id=J_V_CUSTOMERID AND LOGIN_ID=J_V_GUARDIAN_LOGIN;	
		IF V_USER_ID_FOR_GUARDIAN =0 THEN
				CALL SP_INSERT_USER_MASTER(J_V_GUARDIAN_LOGIN 	,
                                          J_V_GUARDIAN_LOGIN_PASSWORD	,
                                          J_V_GUARDIAN_FIRST_NAME,
                                          J_V_GUARDIAN_MIDDLE_NAME 	,
                                          J_V_GUARDIAN_LAST_NAME 	,
					  V_USERTYPEID_FOR_GUARDIAN	,
                                          V_ACTIVE	,
                                          J_V_CUSTOMERID	,
                                          J_V_GUARDIAN_CONTACTNO 	,
                                          J_V_GUARDIAN_ADDRESS 	,
                                          J_V_GUARDIAN_NOTIFICATION_ID 	,
                                          J_V_CREATED_DATE	,
                                          J_V_CREATED_BY	,
                                          V_MODIFIED_DATE	,
                                          V_MODIFIED_BY	,
                                          @V_USER_ID_FOR_GUARDIAN);
		END IF;
		
		
		#Check whether Student exists or not 
		SELECT IFNULL(ID,0)  INTO V_STUDENT_ID
        FROM STUDENT WHERE USER_ID=V_USER_ID_FOR_STUDENT ;	
		
		IF V_STUDENT_ID=0 then 
	
		CALL SP_INSERT_STUDENT
					(
			  
			V_USER_ID_FOR_STUDENT,
			J_V_STUDENT_ROLLNO,
			V_USER_ID_FOR_GUARDIAN,
			J_V_IS_ENROLLED,
			V_ACTIVE,
			J_V_CREATED_BY,
			J_V_CREATED_DATE ,
			V_MODIFIED_BY,
			V_MODIFIED_DATE,
			@V_STUDENT_ID
			);
	    END IF;	
 
		#Check whether Student exists or not 
		SELECT IFNULL(ID,0)  INTO V_STUDENT_DETAIL_ID
        FROM STUDENT_DETAILS WHERE STUDENT_ID=V_STUDENT_ID ;
 
     IF   	V_STUDENT_DETAIL_ID=0 THEN	
		CALL SP_INSERT_STUDENT_DETAILS(
		V_STUDENT_ID,
		J_V_STUDENT_ACADEMIC_INSTITUTE,
		J_V_STUDENT_IMAGE_PATH,
		J_V_FATHER_FIRST_NAME,
		J_V_FATHER_LAST_NAME,
		J_V_FATHER_CONTACTNO,
		J_V_FATHER_ANUAL_INCOME,
		J_V_FATHER_QUALIFICATION,
		J_V_FATHER_OCCUPATION,
		J_V_MOTHER_FIRST_NAME,
		J_V_MOTHER_LAST_NAME,
		J_V_MOTHER_QUALIFICATION,
		J_V_MOTHER_OCCUPATION,
		J_V_MOTHER_CONTACTNO,
		J_V_MOTHER_ANUAL_INCOME,
		J_V_STUDENT_DATE_OF_BIRTH ,
		J_V_STUDENT_QUALIFICATION,
		J_V_CREATED_BY,
		J_V_CREATED_DATE,
		V_MODIFIED_BY,
		V_MODIFIED_DATE ,
		@V_STUDENT_DETAIL_ID);

    END IF;
          COMMIT;
	END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
