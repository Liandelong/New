USE [master]
GO
/****** Object:  Database [NewSystem]    Script Date: 05/19/2019 10:49:30 ******/
CREATE DATABASE [NewSystem] ON  PRIMARY 
( NAME = N'NewSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\NewSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NewSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\NewSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NewSystem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewSystem] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NewSystem] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NewSystem] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NewSystem] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NewSystem] SET ARITHABORT OFF
GO
ALTER DATABASE [NewSystem] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NewSystem] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NewSystem] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NewSystem] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NewSystem] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NewSystem] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NewSystem] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NewSystem] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NewSystem] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NewSystem] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NewSystem] SET  DISABLE_BROKER
GO
ALTER DATABASE [NewSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NewSystem] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NewSystem] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NewSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NewSystem] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NewSystem] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NewSystem] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NewSystem] SET  READ_WRITE
GO
ALTER DATABASE [NewSystem] SET RECOVERY FULL
GO
ALTER DATABASE [NewSystem] SET  MULTI_USER
GO
ALTER DATABASE [NewSystem] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NewSystem] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'NewSystem', N'ON'
GO
USE [NewSystem]
GO
/****** Object:  User [lian]    Script Date: 05/19/2019 10:49:30 ******/
CREATE USER [lian] FOR LOGIN [lian] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[News]    Script Date: 05/19/2019 10:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](32) NULL,
	[Msg] [nvarchar](max) NULL,
	[SubDateTime] [datetime] NOT NULL,
	[Author] [nvarchar](32) NULL,
	[ImagePath] [nvarchar](100) NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK__News__3214EC0703317E3D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[News] ON
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (4, N'英雄联盟', N'贼好玩', CAST(0x0000A99E00000000 AS DateTime), N'神秘人', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (6, N'学校寒假时间', N'时间非常长1月19日放假', CAST(0x0000A9A800000000 AS DateTime), N'学校', NULL, 3)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (11, N'电子科技大学中山学院', N'&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;我学校非常漂亮', CAST(0x0000A9A500000000 AS DateTime), N'练德龙', NULL, 6)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (12, N'表情包1', N'<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/12.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/6.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/28.gif" border="0" alt="" />', CAST(0x0000A9A500000000 AS DateTime), N'练德龙', NULL, 1)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (15, N'老鹰捉小鸡', N'漂亮', CAST(0x0000A9A500000000 AS DateTime), N'中山', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (19, N'狼人杀', N'<p>
	45132132132132
</p>
<p>
	<img src="/Upload/KinderEditorImages/image/20181128/20181128130227_3849.jpg" width="80" height="80" alt="" /> 
</p>
<p>
	99999999999
</p>
<p>
	<img src="/Upload/KinderEditorImages/image/20181128/20181128130301_3797.png" width="90" height="90" alt="" /> 
</p>
<p>
	<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/28.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/12.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/41.gif" border="0" alt="" /> 
</p>', CAST(0x0000A9A600000000 AS DateTime), N'练德龙', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (20, N'电子科技大学中山学院', N'<p>
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>电子科技大学</strong> 
</p>
<p>
	<strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</strong>你好，我是作者练德龙。东方航空技术可能不健康的内部开始就能把的回复即可打开的疯狂的进攻得分你不觉得你看额头日日日日日日日日日日日日日日日日日蛋糕烦烦烦烦烦烦蛋糕威威威威威威威威威威
</p>
<p style="margin-top:0px;margin-bottom:0px;padding:0px;color:#333333;font-family:&quot;font-size:16px;white-space:pre-wrap;background-color:#FFFFFF;">
	$("#tt").tabs(''update'',{<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tab: tab,<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; options:{
</p>
<span style="color:#333333;font-family:&quot;font-size:16px;white-space:pre-wrap;background-color:#FFFFFF;"> </span> 
<p style="margin-top:0px;margin-bottom:0px;padding:0px;color:#333333;font-family:&quot;font-size:16px;white-space:pre-wrap;background-color:#FFFFFF;">
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; href: url<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br />
&nbsp;&nbsp;&nbsp; });<br />
&nbsp;&nbsp;&nbsp; tab.panel(''refresh'');
</p>
<p>
	<br />
</p>', CAST(0x0000A9A600DBEEBC AS DateTime), N'练德龙', NULL, 3)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (21, N'材食团委举办策划书撰写培训', N'<p>
	&nbsp; &nbsp; &nbsp; &nbsp;为了提升学生干部的策划书撰写技能，推动各项学生活动的顺利开展，<span style="color:#E53333;">材料与食品</span>学院团委于11月26号晚上组织了2018级学生干部共80人在厚德楼A106进行了策划书培训。
</p>
<p>
	&nbsp; &nbsp; &nbsp;&nbsp;本次培训由材料与食品学院团委第十四届社会实践部部长陈昱君同学主讲，她首先为大家讲解了什么是策划书和策划书的格式要求，再结合具体案例详细讲解了如何完成一份策划书，列举了策划书的常见错误和应注意的问题，还现场示范了如何编辑一份简洁明了的策划书，演示了Word文档的编辑技巧和表格的调整来对策划书内容进行优化，使策划书内容更加整洁。
</p>
<p>
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<img src="/Upload/KinderEditorImages/image/20190305/20190305204017_0059.png" width="80" height="80" alt="" /> 
</p>
<p>
	&nbsp; &nbsp; &nbsp;培训结束后，团委办公室主任陈美玲同学对本次培训进行了总结，她说，一份优秀的策划书是举办好一个活动的关键，团委举办这样的培训是希望提升大家的工作技能，希望大家珍惜学习的机会，今后努力做到学有所用。
</p>', CAST(0x0000A9A600000000 AS DateTime), N'练德龙', NULL, 3)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (22, N'王者荣誉', N'哈哈', CAST(0x0000A9C900000000 AS DateTime), N'练德龙', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (24, N'吃鸡战场', N'<p>
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;微软<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/20.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/27.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/36.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/38.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/38.gif" border="0" alt="" /><img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/19.gif" border="0" alt="" /> 
</p>
<p>
	&nbsp; &nbsp; &nbsp; .net三层框架
</p>', CAST(0x0000A9DB00000000 AS DateTime), N'UZI', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (25, N'6668', N'<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/0.gif" border="0" alt="" />
<p>
	&nbsp;s<strong>dfsfd</strong>你好 8&nbsp; 7999999999999999999999<span style="background-color:#009900;">9999999999999</span>999999999999999999999999999999999999555
</p>
<p>
	555555555999999999999999999<span style="background-color:#00D5FF;">9999999999999999999999999999999</span>9999999999999999
</p>
<p>
	99999999945641546548948645<span style="background-color:#E53333;">467898465451654613216564897445623123</span>123156456487
</p>
<p>
	86451231231231212315646546545645645646666666666666666666666666666666666666
</p>
<p>
	66666666665
</p>', CAST(0x0000A9E600000000 AS DateTime), N'666', NULL, 5)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (26, N'广州', N'<p>
	&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/12.gif" border="0" alt="" />工作的地方<img src="http://localhost:51129/KinderEditor/plugins/emoticons/images/28.gif" border="0" alt="" /> 
</p>
<div class="para" label-module="para" style="font-size:14px;color:#333333;margin-bottom:15px;text-indent:28px;line-height:24px;zoom:1;font-family:arial, 宋体, sans-serif;white-space:normal;background-color:#FFFFFF;">
	广州，简称<a target="_blank" href="https://baike.baidu.com/item/%E7%A9%97/5720" data-lemmaid="5720" style="color:#136EC2;text-decoration-line:none;">穗</a>，别称<a target="_blank" href="https://baike.baidu.com/item/%E7%BE%8A%E5%9F%8E/425628" data-lemmaid="425628" style="color:#136EC2;text-decoration-line:none;">羊城</a>、<a target="_blank" href="https://baike.baidu.com/item/%E8%8A%B1%E5%9F%8E/16449" data-lemmaid="16449" style="color:#136EC2;text-decoration-line:none;">花城</a>，是<a target="_blank" href="https://baike.baidu.com/item/%E5%B9%BF%E4%B8%9C%E7%9C%81/132473" data-lemmaid="132473" style="color:#136EC2;text-decoration-line:none;">广东省</a>省会、<a target="_blank" href="https://baike.baidu.com/item/%E5%89%AF%E7%9C%81%E7%BA%A7%E5%B8%82" style="color:#136EC2;text-decoration-line:none;">副省级市</a>、<a target="_blank" href="https://baike.baidu.com/item/%E5%9B%BD%E5%AE%B6%E4%B8%AD%E5%BF%83%E5%9F%8E%E5%B8%82/842500" data-lemmaid="842500" style="color:#136EC2;text-decoration-line:none;">国家中心城市</a>、<a target="_blank" href="https://baike.baidu.com/item/%E8%B6%85%E5%A4%A7%E5%9F%8E%E5%B8%82/413865" data-lemmaid="413865" style="color:#136EC2;text-decoration-line:none;">超大城市</a>、<a target="_blank" href="https://baike.baidu.com/item/%E5%9B%BD%E9%99%85%E5%A4%A7%E9%83%BD%E5%B8%82/3929879" data-lemmaid="3929879" style="color:#136EC2;text-decoration-line:none;">国际大都市</a>、国际商贸中心、国际<a target="_blank" href="https://baike.baidu.com/item/%E7%BB%BC%E5%90%88%E4%BA%A4%E9%80%9A%E6%9E%A2%E7%BA%BD/1417280" data-lemmaid="1417280" style="color:#136EC2;text-decoration-line:none;">综合交通枢纽</a>、国家综合性<a target="_blank" href="https://baike.baidu.com/item/%E9%97%A8%E6%88%B7%E5%9F%8E%E5%B8%82/7109664" data-lemmaid="7109664" style="color:#136EC2;text-decoration-line:none;">门户城市</a>，首批<a target="_blank" href="https://baike.baidu.com/item/%E6%B2%BF%E6%B5%B7%E5%BC%80%E6%94%BE%E5%9F%8E%E5%B8%82/10548433" data-lemmaid="10548433" style="color:#136EC2;text-decoration-line:none;">沿海开放城市</a>，是<a target="_blank" href="https://baike.baidu.com/item/%E5%8D%97%E9%83%A8%E6%88%98%E5%8C%BA/19330641" data-lemmaid="19330641" style="color:#136EC2;text-decoration-line:none;">南部战区</a>司令部驻地<span class="sup--normal" data-sup="1-2" data-ctrmap=":1,:2," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[1-2]</span><a name="ref_[1-2]_10628575"></a>&nbsp;&nbsp;。广州地处广东省中南部，<a target="_blank" href="https://baike.baidu.com/item/%E7%8F%A0%E6%B1%9F%E4%B8%89%E8%A7%92%E6%B4%B2/621061" data-lemmaid="621061" style="color:#136EC2;text-decoration-line:none;">珠江三角洲</a>北缘，濒临<a target="_blank" href="https://baike.baidu.com/item/%E5%8D%97%E6%B5%B7/27429" data-lemmaid="27429" style="color:#136EC2;text-decoration-line:none;">南海</a>，邻近<a target="_blank" href="https://baike.baidu.com/item/%E9%A6%99%E6%B8%AF/128775" data-lemmaid="128775" style="color:#136EC2;text-decoration-line:none;">香港</a>、<a target="_blank" href="https://baike.baidu.com/item/%E6%BE%B3%E9%97%A8/24335" data-lemmaid="24335" style="color:#136EC2;text-decoration-line:none;">澳门</a>，是中国通往世界的<a target="_blank" href="https://baike.baidu.com/item/%E5%8D%97%E5%A4%A7%E9%97%A8/2934486" data-lemmaid="2934486" style="color:#136EC2;text-decoration-line:none;">南大门</a>，是<a target="_blank" href="https://baike.baidu.com/item/%E7%B2%A4%E6%B8%AF%E6%BE%B3%E5%A4%A7%E6%B9%BE%E5%8C%BA/19153589" data-lemmaid="19153589" style="color:#136EC2;text-decoration-line:none;">粤港澳大湾区</a>、<a target="_blank" href="https://baike.baidu.com/item/%E6%B3%9B%E7%8F%A0%E6%B1%9F%E4%B8%89%E8%A7%92%E6%B4%B2%E7%BB%8F%E6%B5%8E%E5%8C%BA/6204765" data-lemmaid="6204765" style="color:#136EC2;text-decoration-line:none;">泛珠江三角洲经济区</a>的中心城市以及“<a target="_blank" href="https://baike.baidu.com/item/%E4%B8%80%E5%B8%A6%E4%B8%80%E8%B7%AF/13132427" data-lemmaid="13132427" style="color:#136EC2;text-decoration-line:none;">一带一路</a>”的枢纽城市。<span class="sup--normal" data-sup="3-6" data-ctrmap=":3,:4,:5,:6," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[3-6]</span><a name="ref_[3-6]_10628575"></a>&nbsp;
</div>
<div class="para" label-module="para" style="font-size:14px;color:#333333;margin-bottom:15px;text-indent:28px;line-height:24px;zoom:1;font-family:arial, 宋体, sans-serif;white-space:normal;background-color:#FFFFFF;">
	广州是<a target="_blank" href="https://baike.baidu.com/item/%E5%9B%BD%E5%AE%B6%E5%8E%86%E5%8F%B2%E6%96%87%E5%8C%96%E5%90%8D%E5%9F%8E/6412721" data-lemmaid="6412721" style="color:#136EC2;text-decoration-line:none;">国家历史文化名城</a>，从<a target="_blank" href="https://baike.baidu.com/item/%E7%A7%A6%E6%9C%9D" style="color:#136EC2;text-decoration-line:none;">秦朝</a>开始，广州一直是郡治、州治、府治的行政中心；一直是<a target="_blank" href="https://baike.baidu.com/item/%E5%8D%8E%E5%8D%97%E5%9C%B0%E5%8C%BA/7596721" data-lemmaid="7596721" style="color:#136EC2;text-decoration-line:none;">华南地区</a>的政治、军事、经济、文化和科教中心，是<a target="_blank" href="https://baike.baidu.com/item/%E5%B2%AD%E5%8D%97%E6%96%87%E5%8C%96/819521" data-lemmaid="819521" style="color:#136EC2;text-decoration-line:none;">岭南文化</a>的发源地和兴盛地。广州从3世纪30年代起成为<a target="_blank" href="https://baike.baidu.com/item/%E6%B5%B7%E4%B8%8A%E4%B8%9D%E7%BB%B8%E4%B9%8B%E8%B7%AF" style="color:#136EC2;text-decoration-line:none;">海上丝绸之路</a>的主港，唐宋时期成为中国第一大港，是世界著名的东方港市；<a target="_blank" href="https://baike.baidu.com/item/%E6%98%8E%E6%B8%85/22266403" data-lemmaid="22266403" style="color:#136EC2;text-decoration-line:none;">明清</a>时期是中国唯一的对外贸易大港，是世界上唯一2000多年长盛不衰的大港。<span class="sup--normal" data-sup="7-8" data-ctrmap=":7,:8," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[7-8]</span><a name="ref_[7-8]_10628575"></a>&nbsp;
</div>
<div class="para" label-module="para" style="font-size:14px;color:#333333;margin-bottom:15px;text-indent:28px;line-height:24px;zoom:1;font-family:arial, 宋体, sans-serif;white-space:normal;background-color:#FFFFFF;">
	广州市总面积7434平方公里，辖11个市辖区，属海洋性<a target="_blank" href="https://baike.baidu.com/item/%E4%BA%9A%E7%83%AD%E5%B8%A6%E5%AD%A3%E9%A3%8E%E6%B0%94%E5%80%99" style="color:#136EC2;text-decoration-line:none;">亚热带季风气候</a>。广州是华南地区最大的城市<span class="sup--normal" data-sup="9" data-ctrmap=":9," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[9]</span><a name="ref_[9]_10628575"></a>&nbsp;&nbsp;。广州被全球权威机构GaWC评为<a target="_blank" href="https://baike.baidu.com/item/%E4%B8%96%E7%95%8C%E4%B8%80%E7%BA%BF%E5%9F%8E%E5%B8%82/4722524" data-lemmaid="4722524" style="color:#136EC2;text-decoration-line:none;">世界一线城市</a><span class="sup--normal" data-sup="10" data-ctrmap=":10," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[10]</span><a name="ref_[10]_10628575"></a>&nbsp;&nbsp;。每年在广州举办的“<a target="_blank" href="https://baike.baidu.com/item/%E4%B8%AD%E5%9B%BD%E8%BF%9B%E5%87%BA%E5%8F%A3%E5%95%86%E5%93%81%E4%BA%A4%E6%98%93%E4%BC%9A/10312424" data-lemmaid="10312424" style="color:#136EC2;text-decoration-line:none;">中国进出口商品交易会</a>”，吸引了大量客商以及大量<a target="_blank" href="https://baike.baidu.com/item/%E5%A4%96%E8%B5%84%E4%BC%81%E4%B8%9A/1168372" data-lemmaid="1168372" style="color:#136EC2;text-decoration-line:none;">外资企业</a>、<a target="_blank" href="https://baike.baidu.com/item/%E4%B8%96%E7%95%8C500%E5%BC%BA%E4%BC%81%E4%B8%9A/5610320" data-lemmaid="5610320" style="color:#136EC2;text-decoration-line:none;">世界500强企业</a>的投资<span class="sup--normal" data-sup="11" data-ctrmap=":11," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[11]</span><a name="ref_[11]_10628575"></a>&nbsp;&nbsp;。广州的<a target="_blank" href="https://baike.baidu.com/item/%E5%9B%BD%E5%AE%B6%E9%AB%98%E6%96%B0%E6%8A%80%E6%9C%AF%E4%BC%81%E4%B8%9A/10033109" data-lemmaid="10033109" style="color:#136EC2;text-decoration-line:none;">国家高新技术企业</a>达8700多家，总量居全国前三。广州集结了全省80%的高校、70%的科技人员，在校大学生总量居全国第一。<span class="sup--normal" data-sup="12-13" data-ctrmap=":12,:13," style="font-size:10.5px;line-height:0;position:relative;vertical-align:baseline;top:-0.5em;margin-left:2px;color:#3366CC;cursor:pointer;padding:0px 2px;">&nbsp;[12-13]</span><a name="ref_[12-13]_10628575"></a>&nbsp;
</div>
<p>
	<br />
</p>', CAST(0x0000A9DB00000000 AS DateTime), N'黄埔区', NULL, 8)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (27, N'抖音', N'234', CAST(0x0000AA0C00CD4C6F AS DateTime), N'李雪琴', NULL, 2)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (29, N'中山市', N'<img src="/Upload/KinderEditorImages/image/20190503/20190503114359_5123.jpg" width="100" height="100" alt="" />一个美丽的城市0', CAST(0x0000AA4200000000 AS DateTime), N'练德龙', NULL, 1)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (31, N'1', N'<img src="/Upload/KinderEditorImages/image/20190503/20190503120142_1270.jpg" width="23" height="23" alt="" />232323', CAST(0x0000AA4200C64FCB AS DateTime), N'2', NULL, 1)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (32, N'0760666', N'<img src="/Upload/KinderEditorImages/image/20190503/20190503120539_6562.png" width="200" height="200" title="666" alt="666" />漂亮', CAST(0x0000AA4200C75AE9 AS DateTime), N'练德龙', NULL, 1)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (33, N'广州77', N'<img src="/Upload/KinderEditorImages/image/20190503/20190503123849_0295.jpg" width="100" height="100" alt="" />999', CAST(0x0000AA4200D07023 AS DateTime), N'练德龙', NULL, 1)
INSERT [dbo].[News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath], [TypeId]) VALUES (34, N'美女', N'的发表的吧地方吧·<img src="/Upload/KinderEditorImages/image/20190507/20190507235421_2983.jpg" width="100" height="100" alt="" />', CAST(0x0000AA460189F790 AS DateTime), N'中山', NULL, 3)
SET IDENTITY_INSERT [dbo].[News] OFF
/****** Object:  Table [dbo].[UserInfo]    Script Date: 05/19/2019 10:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](32) NOT NULL,
	[UserPwd] [nvarchar](32) NOT NULL,
	[UserMail] [nvarchar](32) NULL,
	[RegTime] [datetime] NOT NULL,
	[IsAdmin] [int] NOT NULL,
 CONSTRAINT [PK__UserInfo__3214EC077F60ED59] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([Id], [UserName], [UserPwd], [UserMail], [RegTime], [IsAdmin]) VALUES (3, N'练德龙', N'660697', N'1147732739@qq.com', CAST(0x0000A99B0143DB62 AS DateTime), 1)
INSERT [dbo].[UserInfo] ([Id], [UserName], [UserPwd], [UserMail], [RegTime], [IsAdmin]) VALUES (8, N'李白', N'654321', N'', CAST(0x0000AA0B01752D08 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  Table [dbo].[NewsType]    Script Date: 05/19/2019 10:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK__NewsType__3214EC070AD2A005] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NewsType] ON
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (1, N'其它')
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (2, N'游戏')
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (3, N'校园')
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (5, N'教育')
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (6, N'学术')
INSERT [dbo].[NewsType] ([Id], [Type]) VALUES (8, N'公益')
SET IDENTITY_INSERT [dbo].[NewsType] OFF
/****** Object:  Table [dbo].[NewsComments]    Script Date: 05/19/2019 10:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewId] [int] NOT NULL,
	[UserId] [int] NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK__NewsComm__3214EC0707020F21] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NewsComments] ON
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (1, 26, 7, N'广州好漂亮', CAST(0x0000AA0B0187FBE1 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (2, 21, 3, N'666', CAST(0x0000AA0C0000FBEB AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (5, 15, 3, N'66', CAST(0x0000AA0C000625CC AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (6, 19, 8, N'2', CAST(0x0000AA0C000E0462 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (7, 26, 8, N'真漂亮', CAST(0x0000AA0C0017C8C2 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (8, 26, 8, N'666', CAST(0x0000AA0C0017D687 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (9, 26, 3, N'你好棒棒棒', CAST(0x0000AA0C0018BEF3 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (10, 15, 3, N'9', CAST(0x0000AA0C0018FB2F AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (11, 24, 8, N'李白吃鸡', CAST(0x0000AA0C001A8C3F AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (12, 24, 8, N'哈哈', CAST(0x0000AA0C001A9399 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (13, 20, 8, N'好学校', CAST(0x0000AA0C00CC7A08 AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (14, 20, 8, N'888', CAST(0x0000AA0C00CC831B AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (15, 20, 8, N'55', CAST(0x0000AA0C00CC87AC AS DateTime))
INSERT [dbo].[NewsComments] ([Id], [NewId], [UserId], [Msg], [CreateDateTime]) VALUES (16, 26, 8, N'4', CAST(0x0000AA0C01127781 AS DateTime))
SET IDENTITY_INSERT [dbo].[NewsComments] OFF
/****** Object:  View [dbo].[NewsAndType]    Script Date: 05/19/2019 10:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NewsAndType]
AS
SELECT     dbo.News.Id, dbo.News.Title, dbo.News.Msg, dbo.News.SubDateTime, dbo.News.Author, dbo.News.ImagePath, dbo.NewsType.Type, dbo.News.TypeId
FROM         dbo.News INNER JOIN
                      dbo.NewsType ON dbo.News.TypeId = dbo.NewsType.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[28] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "News"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 189
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NewsType"
            Begin Extent = 
               Top = 24
               Left = 328
               Bottom = 116
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NewsAndType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NewsAndType'
GO
/****** Object:  View [dbo].[Comments]    Script Date: 05/19/2019 10:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Comments]
AS
SELECT     dbo.News.Title, dbo.News.Author, dbo.NewsComments.Msg, dbo.NewsComments.CreateDateTime, dbo.UserInfo.UserName, dbo.NewsComments.Id
FROM         dbo.News INNER JOIN
                      dbo.NewsComments ON dbo.News.Id = dbo.NewsComments.NewId INNER JOIN
                      dbo.UserInfo ON dbo.NewsComments.UserId = dbo.UserInfo.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "News"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NewsComments"
            Begin Extent = 
               Top = 97
               Left = 249
               Bottom = 217
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 31
               Left = 545
               Bottom = 151
               Right = 687
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Comments'
GO
