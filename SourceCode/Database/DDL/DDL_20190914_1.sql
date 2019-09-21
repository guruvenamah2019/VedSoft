 
 CREATE  TABLE STUDENT
 (ID INTEGER PRIMARY KEY,
  USER_ID INTEGER ,
  CUSTOMER_ID INTEGER,
  FATHER_USER_ID INTEGER,
  MOTHER_USER_ID INTEGER,
  GUARDIAN_USER_ID INTEGER,
  IS_ENROLLED INTEGER,
  ACTIVE INTEGER,
  CREATED_BY INTEGER,
  CREATED_DATE DATE,
  MODIFIED_BY INTEGER,
  MODIFIED_DATE DATE, 
CONSTRAINT STUDENT_FK1
FOREIGN KEY  (USER_ID)
REFERENCES USER_MASTER(ID),
CONSTRAINT STUDENT_FK2
FOREIGN KEY  (CUSTOMER_ID)
REFERENCES CUSTOMER_MASTER(ID),
CONSTRAINT STUDENT_FK3
FOREIGN KEY  (FATHER_USER_ID)
REFERENCES USER_MASTER(ID),
CONSTRAINT STUDENT_FK4
FOREIGN KEY  (MOTHER_USER_ID)
REFERENCES USER_MASTER(ID)
  );

CREATE TABLE ADMISSION_TYPE
(ID INTEGER PRIMARY KEY,
NAME VARCHAR(100)
);


CREATE   TABLE STUDENT_ADMISSION_DETAILS
(ID INTEGER PRIMARY KEY,
STUDENT_ID INTEGER,
BRANCH_ID INTEGER,
CUSTOMER_ID INTEGER,
ACADEMIC_YEARID INTEGER,
DATE_OF_ADMISSION DATE,
ADMISSION_TYPEID  INTEGER,-- renew,new,provisional etc
CREATED_DATE DATE,
CREATED_BY INTEGER,
MODIFIED_DATE DATE,
MODIFIED_BY INTEGER,
CONSTRAINT STUDENT_ADMISSION_DETAILS_FK1
FOREIGN KEY  (STUDENT_ID)
REFERENCES STUDENT(ID),
CONSTRAINT STUDENT_ADMISSION_DETAILS_FK5
FOREIGN KEY  (CUSTOMER_ID)
REFERENCES CUSTOMER_MASTER(ID),
CONSTRAINT STUDENT_ADMISSION_DETAILS_FK2
FOREIGN KEY  (BRANCH_ID)
REFERENCES CUSTOMER_BRANCHES(ID),
CONSTRAINT STUDENT_ADMISSION_DETAILS_FK3
FOREIGN KEY  (ADMISSION_TYPEID)
REFERENCES ADMISSION_TYPE(ID),
CONSTRAINT STUDENT_ADMISSION_DETAILS_FK4
FOREIGN KEY  (ACADEMIC_YEARID)
REFERENCES ACADEMIC_YEARS(ID)
);

 
CREATE   TABLE STUDENT_COURSES
(ID INTEGER PRIMARY KEY,
STUDENT_ID INTEGER,
BRANCH_COURSES_ID INTEGER,
COURSE_FEE_AMOUNT DECIMAL,
DISCOUNT_ALLOWED INTEGER,
DISCOUNTED_FEE_AMOUNT DECIMAL,
ACTIVE INTEGER,
CREATED_DATE DATE,
CREATED_BY INTEGER,
MODIFIED_DATE DATE,
MODIFIED_BY INTEGER,
CONSTRAINT STUDENT_COURSES_FK1
FOREIGN KEY  (STUDENT_ID)
REFERENCES STUDENT(ID),
CONSTRAINT STUDENT_COURSES_FK2
FOREIGN KEY  (BRANCH_COURSES_ID)
REFERENCES BRANCH_COURSES(ID)
);

ALTER TABLE ACADEMIC_YEARS ADD ACTIVE INTEGER(1);
ALTER TABLE ACADEMIC_YEARS ADD CREATED_BY INTEGER;
ALTER TABLE ACADEMIC_YEARS ADD CREATED_DATE DATETIME;
ALTER TABLE ACADEMIC_YEARS ADD MODIFIED_BY INTEGER;
ALTER TABLE ACADEMIC_YEARS ADD MODIFIED_DATE DATETIME;

ALTER TABLE ADMISSION_TYPE ADD ACTIVE INTEGER(1);
ALTER TABLE ADMISSION_TYPE ADD CREATED_BY INTEGER;
ALTER TABLE ADMISSION_TYPE ADD CREATED_DATE DATETIME;
ALTER TABLE ADMISSION_TYPE ADD MODIFIED_BY INTEGER;
ALTER TABLE ADMISSION_TYPE ADD MODIFIED_DATE DATETIME;
ALTER TABLE ACADEMIC_YEARS ADD ACTIVE INTEGER(1);
ALTER TABLE ACADEMIC_YEARS ADD CREATED_BY INTEGER;
ALTER TABLE ACADEMIC_YEARS ADD CREATED_DATE DATETIME;
ALTER TABLE ACADEMIC_YEARS ADD MODIFIED_BY INTEGER;
ALTER TABLE ACADEMIC_YEARS ADD MODIFIED_DATE DATETIME;
ALTER TABLE ACADEMIC_YEARS ADD CUSTOMER_ID INTEGER(11);

ALTER TABLE ADMISSION_TYPE ADD CUSTOMER_ID INTEGER(11);
ALTER TABLE ADMISSION_TYPE ADD ACTIVE INTEGER(1);
ALTER TABLE ADMISSION_TYPE ADD CREATED_BY INTEGER;
ALTER TABLE ADMISSION_TYPE ADD CREATED_DATE DATETIME;
ALTER TABLE ADMISSION_TYPE ADD MODIFIED_BY INTEGER;
ALTER TABLE ADMISSION_TYPE ADD MODIFIED_DATE DATETIME