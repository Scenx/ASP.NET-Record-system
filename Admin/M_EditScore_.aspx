<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditScore_.aspx.cs" Inherits="_.Admin.M_EditScore_" %>
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
            var score = document.getElementById("score").value;
            if(score == ""){
                alert("������ɼ��÷�...");
                document.getElementById("score").focus();
                return false;
            }
            else if (!re.test(score))
            {
                alert("�ɼ��÷�����������");
                document.getElementById("score").focus();
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
    <div class="Body_Title">�ɼ���Ϣ���� �����༭�ɼ���Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ����ѧ����</td>
                    <td width="650px;">
                         <asp:DropDownList ID="studentNo" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �����γ̣�</td>
                    <td width="650px;">
                         <asp:DropDownList ID="courseNo" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ����ѧ�ڣ�</td>
                    <td width="650px;">
                         <asp:DropDownList ID="termId" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �ɼ��÷֣�</td>
                    <td width="650px;">
                         <input id="score" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>������ɼ��÷֣�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnScore_Save" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnScore_Save_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

