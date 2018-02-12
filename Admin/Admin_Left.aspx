<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学期信息管理</div>
        <div class="MenuNote" style="display:none;" id="TermInfo_Div" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditTermInfo_.aspx" target="main">添加学期信息</a></li>
                <li><a href="M_TermInfo_List.aspx" target="main">学期信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;班级信息管理</div>
        <div class="MenuNote" style="display:none;" id="Class_Div" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditClass_.aspx" target="main">添加班级信息</a></li>
                <li><a href="M_Class_List.aspx" target="main">班级信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生信息管理</div>
        <div class="MenuNote" style="display:none;" id="Student_Div" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditStudent_.aspx" target="main">添加学生信息</a></li>
                <li><a href="M_Student_List.aspx" target="main">学生信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;课程信息管理</div>
        <div class="MenuNote" style="display:none;" id="Course_Div" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCourse_.aspx" target="main">添加课程信息</a></li>
                <li><a href="M_Course_List.aspx" target="main">课程信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;成绩信息管理</div>
        <div class="MenuNote" style="display:none;" id="Score_Div" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditScore_.aspx" target="main">添加成绩信息</a></li>
                <li><a href="M_Score_List.aspx" target="main">成绩信息查询</a></li> 
            </ul>
        </div>
 

         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
