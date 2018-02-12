<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditCourse_.aspx.cs" Inherits="_.Admin.M_EditCourse_" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="JavaScript/date.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var courseNo = document.getElementById("courseNo").value;
            if (courseNo == "") {
                alert("请输入课程编号...");
                document.getElementById("courseNo").focus();
                return false;
            }

            var courseName = document.getElementById("courseName").value;
            if (courseName == "") {
                alert("请输入课程名称...");
                document.getElementById("courseName").focus();
                return false;
            }

            var courseCount = document.getElementById("courseCount").value;
            if(courseCount == ""){
                alert("请输入总课时...");
                document.getElementById("courseCount").focus();
                return false;
            }
            else if (!resc.test(courseCount))
            {
                alert("总课时请输入数字");
                document.getElementById("courseCount").focus();
                //input.rate.focus();
                return false;
            }

            var courseScore = document.getElementById("courseScore").value;
            if(courseScore == ""){
                alert("请输入课程学分...");
                document.getElementById("courseScore").focus();
                return false;
            }
            else if (!re.test(courseScore))
            {
                alert("课程学分请输入数字");
                document.getElementById("courseScore").focus();
                //input.rate.focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">课程信息管理 》》编辑课程信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   课程编号：</td>
                    <td width="650px;">
                         <input id="courseNo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入课程编号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   课程名称：</td>
                    <td width="650px;">
                         <input id="courseName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入课程名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   任课老师：</td>
                    <td width="650px;">
                         <input id="teacherName" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   总课时：</td>
                    <td width="650px;">
                         <input id="courseCount" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入总课时！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   课程学分：</td>
                    <td width="650px;">
                         <input id="courseScore" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入课程学分！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCourse_Save" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnCourse_Save_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

