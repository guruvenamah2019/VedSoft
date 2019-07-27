
CREATE TABLE VEDIC_INSTITUTION_TYPE
(ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250)
);



CREATE TABLE VEDIC_EDUCATIONAL_INSTITUTIONS
(ID INTEGER PRIMARY KEY AUTO_INCREMENT,
INSTITUTION_TYPE_ID INTEGER,
NAME VARCHAR(250),
CONSTRAINT EDUCATIONAL_INSTITUTIONS_FK FOREIGN KEY (INSTITUTION_TYPE_ID)REFERENCES INSTITUTION_TYPE(ID)
);


CREATE   TABLE VEDIC_COURSE_TYPE
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
COURSE_TYPE_NAME VARCHAR(250),
EDUCATIONAL_INSTITUTIONS_ID INTEGER,
CONSTRAINT COURSE_TYPE_FK FOREIGN KEY (EDUCATIONAL_INSTITUTIONS_ID) REFERENCES EDUCATIONAL_INSTITUTIONS(ID)
);


CREATE   TABLE DEPARTMENT
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
BRANCH_ID INTEGER,
NAME VARCHAR(250),
DESCRIPTION VARCHAR(250),
CONSTRAINT DEPARTMENT_FK FOREIGN KEY (BRANCH_ID)REFERENCES BRANCH_MASTER(ID)
);


CREATE    TABLE VEDIC_COURSES_MASTER
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250),
COURSE_TYPE_ID INTEGER,
COURSE_DESCRIPTION VARCHAR(250),
COURSE_DURATION_MONTHS VARCHAR(250),
CONSTRAINT COURSES_FK FOREIGN KEY (COURSE_TYPE_ID) REFERENCES COURSE_TYPE(ID)
);

 
CREATE    TABLE VEDIC_COURSE_HIERACHY
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250),
PARENT_ID INTEGER,
CONSTRAINT COURSES_STRUCTURE_HIERACHY_FK1 FOREIGN KEY (PARENT_ID) REFERENCES VEDIC_COURSE_HIERACHY(ID)
);


 
CREATE    TABLE VEDIC_COURSE_HIERACHY_MAPPING
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
COURSE_ID INTEGER NOT NULL,
COURSE_HIERACHY_ID INTEGER NOT NULL,
CONSTRAINT VEDIC_COURSE_HIERACHY_MAPPING_FK1 FOREIGN KEY (COURSE_HIERACHY_ID) REFERENCES VEDIC_COURSE_HIERACHY(ID),
CONSTRAINT VEDIC_COURSE_HIERACHY_MAPPING_FK2 FOREIGN KEY (COURSE_ID) REFERENCES VEDIC_COURSES_MASTER(ID)
);

 
CREATE    TABLE VEDIC_COURSE_HIERACHY_LEVEL
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250)
);


CREATE   TABLE CUSTOMER_COURSES
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250),
DESCRIPTION VARCHAR(250),
CUSTOMER_ID INTEGER,
COURSE_ID INTEGER,
ACTIVE INTEGER,
CONSTRAINT CUSTOMER_COURSES_FK FOREIGN KEY (COURSE_ID) REFERENCES COURSES_MASTER(ID),
CONSTRAINT CUSTOMER_COURSES_FK2 FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER_MASTER(ID)
);


CREATE TABLE BRANCH_COURSES
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
CUSTOMER_COURSES_ID VARCHAR(250),
BRANCH_ID INTEGER,
ACADEMIC_YEAR_ID INTEGER,
ACTIVE INTEGER,
COURSE_DURATION_MONTHS VARCHAR(250),
CONSTRAINT BRANCH_COURSES_FK2 FOREIGN KEY (BRANCH_ID) REFERENCES CUSTOMER_BRANCHES(ID)
);

CREATE   TABLE COURSE_FEE_STRUCTURE
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
BRANCH_COURSE_ID INTEGER,
START_DATE DATE,
END_DATE  DATE,
COST      DECIMAL,
DISCOUNT_ALLOWED DECIMAL,
CONSTRAINT COURSE_FEE_STRUCTURE_FK FOREIGN KEY (BRANCH_COURSE_ID) REFERENCES BRANCH_COURSES(ID)
);

---- branch_course_hiearachy_fee_struc


CREATE     TABLE CUSTOMER_COURSES
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250),
CUSTOMER_ID    INTEGER,
ACITVE INTEGER(1)DEFAULT 1,
VEDIC_COURSE_ID INTEGER,
COURSE_TYPE_ID INTEGER,
COURSE_DESCRIPTION VARCHAR(250),
COURSE_DURATION_MONTHS VARCHAR(250),
COURSE_COST DECIMAL,
CREATED_BY INTEGER,
CREATED_DATE DATETIME,
MODIFIED_BY INTEGER,
MODIFIED_DATE DATETIME,
CONSTRAINT CUSTOMER_COURSES_FK1 FOREIGN KEY (VEDIC_COURSE_ID) REFERENCES VEDIC_COURSES_MASTER(ID),
CONSTRAINT CUSTOMER_COURSES_FK2 FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER_MASTER(ID)
);


CREATE    TABLE CUSTOMER_COURSE_HIERACHY
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
NAME VARCHAR(250),
CUSTOMER_ID INTEGER,
PARENT_ID INTEGER,
ACTIVE INTEGER(1)DEFAULT 1,
CREATED_BY INTEGER,
CREATED_DATE DATETIME,
MODIFIED_BY INTEGER,
MODIFIED_DATE DATETIME,
CONSTRAINT COURSES_STRUCTURE_HIERACHY_FK FOREIGN KEY (PARENT_ID) REFERENCES CUSTOMER_COURSE_HIERACHY(ID),
CONSTRAINT CUSTOMER_COURSE_HIERACHY_FK2 FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER_MASTER(ID)
);

 
CREATE      TABLE  CUSTOMER_COURSE_HIERACHY_MAPPING
(
ID INTEGER PRIMARY KEY AUTO_INCREMENT,
CUSTOMER_ID INTEGER NOT NULL,
CUSTOMER_COURSE_ID INTEGER NOT NULL,
CUSTOMER_COURSE_HIERACHY_ID INTEGER NOT NULL,
ACTIVE INTEGER(1)DEFAULT 1,
CREATED_BY INTEGER,
CREATED_DATE DATETIME,
MODIFIED_BY INTEGER,
MODIFIED_DATE DATETIME,
CONSTRAINT CUSTOMER_COURSE_HIERACHY_MAPPING_FK1 FOREIGN KEY (CUSTOMER_COURSE_HIERACHY_ID) REFERENCES CUSTOMER_COURSE_HIERACHY(ID),
CONSTRAINT CUSTOMER_COURSE_HIERACHY_MAPPING_FK2 FOREIGN KEY (CUSTOMER_COURSE_ID) REFERENCES CUSTOMER_COURSES(ID),
CONSTRAINT CUSTOMER_COURSE_HIERACHY_MAPPING_FK3 FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER_MASTER(ID)
);

