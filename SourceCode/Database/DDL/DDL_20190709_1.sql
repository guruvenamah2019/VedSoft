
CREATE TABLE MODULE_MASTER
(
  ID              INT(4) PRIMARY KEY ,
  CODE            VARCHAR(50),
  NAME            VARCHAR(100),
  DESCRIPTION     VARCHAR(250),
  PARENT_ID       INT(4),
  ACTIVE          INT(1)      DEFAULT 1,
  CREATED_DATE    DATETIME
  );


CREATE  TABLE PRIVILEGE_TYPE
(
  ID             INT(4)PRIMARY KEY,
  NAME           VARCHAR(100)             NOT NULL,
  ACTIVE         INT(1)     NOT NULL DEFAULT 1,
  DESCRIPTION    VARCHAR(250),
  CREATED_DATE   DATE                           
  );


CREATE  TABLE PRIVILEGE_TYPE
(
  ID             INT(4)PRIMARY KEY,
  NAME           VARCHAR(100)             NOT NULL,
  ACTIVE         INT(1)     NOT NULL DEFAULT 1,
  DESCRIPTION    VARCHAR(250),
  CREATED_DATE   DATE                           
  );
  
  
  
CREATE TABLE MODULE_PRIVILEGES
(
  ID             INT(18)PRIMARY KEY,
  MODULE_ID      INT(4),
  PRIVILEGE_TYPE_ID  INT(4),
  ACTIVE         INT(1)                      DEFAULT 1,
  CREATED_DATE   DATE                          
  );

