--ע��BFPUB��BFCRM��ͬһ����Ļ������ļ�����ͼ������ͬһ���⽨�ﻯ��ͼ
--��ҪBFCONFIG��RYXX��XTCZY��XTCZYGRP��XTXX��RCL��SYSLIB�����ͼ��ƽ̨�û���BFPUB8�����±���伴�ɣ�ƽ̨�û���BFPUB10����Ҫ���³�10
/*==============================================================*/
/* View: BFCONFIG                                               */
/*==============================================================*/
grant all on BFPUB8.BFCONFIG to BFCRM10
/
create or replace view BFCRM10.BFCONFIG as
select * from BFPUB8.BFCONFIG where SYSID=510
/

/*==============================================================*/
/* View: RYXX                                                   */
/*==============================================================*/
grant select on BFPUB8.RYXX to BFCRM10
/
create or replace view BFCRM10.RYXX as
select * from BFPUB8.RYXX
/

/*==============================================================*/
/* View: XTCZY                                                  */
/*==============================================================*/
grant select on BFPUB8.XTCZY to BFCRM10
/
create or replace view BFCRM10.XTCZY as
select * from BFPUB8.XTCZY
/

/*==============================================================*/
/* View: XTCZYGRP                                               */
/*==============================================================*/
grant select on BFPUB8.XTCZYGRP to BFCRM10
/
create or replace view BFCRM10.XTCZYGRP as
select * from BFPUB8.XTCZYGRP
/

/*==============================================================*/
/* View: XTXX                                               */
/*==============================================================*/
grant select on BFPUB8.XTXX to BFCRM10
/
create or replace view BFCRM10.XTXX as
select * from BFPUB8.XTXX
/

/*==============================================================*/
/* View: RCL                                               */
/*==============================================================*/
grant select on BFPUB8.RCL to BFCRM10
/
create or replace view BFCRM10.RCL as
select * from BFPUB8.RCL
/

/*==============================================================*/
/* View: SYSLIB                                               */
/*==============================================================*/
grant select on BFPUB8.SYSLIB to BFCRM10
/
create or replace view BFCRM10.SYSLIB as
select * from BFPUB8.SYSLIB
/
