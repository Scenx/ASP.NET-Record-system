<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditTermInfo_.aspx.cs" Inherits="_.Admin.M_EditTermInfo_" %>
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
            var termName = document.getElementById("termName").value;
            if (termName == "") {
                alert("������ѧ������...");
                document.getElementById("termName").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">ѧ����Ϣ���� �����༭ѧ����Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧ�����ƣ�</td>
                    <td width="650px;">
                         <input id="termName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧ�����ƣ�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnTermInfo_Save" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnTermInfo_Save_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

