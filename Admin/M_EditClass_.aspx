<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditClass_.aspx.cs" Inherits="_.Admin.M_EditClass_" %>
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
            var classNo = document.getElementById("classNo").value;
            if (classNo == "") {
                alert("������༶���...");
                document.getElementById("classNo").focus();
                return false;
            }

            var className = document.getElementById("className").value;
            if (className == "") {
                alert("������༶����...");
                document.getElementById("className").focus();
                return false;
            }

            var beginTime = document.getElementById("beginTime").value;
            if (beginTime == "") {
                alert("�����뿪������...");
                document.getElementById("beginTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�༶��Ϣ���� �����༭�༶��Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �༶��ţ�</td>
                    <td width="650px;">
                         <input id="classNo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������༶��ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �༶���ƣ�</td>
                    <td width="650px;">
                         <input id="className" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������༶���ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������������</td>
                    <td width="650px;">
                         <input id="banzhuren" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="beginTime"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnClass_Save" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnClass_Save_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

