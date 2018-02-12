<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditStudent_.aspx.cs" Inherits="_.Admin.M_EditStudent_" %>
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
            var studentNumber = document.getElementById("studentNumber").value;
            if (studentNumber == "") {
                alert("������ѧ��...");
                document.getElementById("studentNumber").focus();
                return false;
            }

            var studentName = document.getElementById("studentName").value;
            if (studentName == "") {
                alert("������ѧ������...");
                document.getElementById("studentName").focus();
                return false;
            }

            var sex = document.getElementById("sex").value;
            if (sex == "") {
                alert("�������Ա�...");
                document.getElementById("sex").focus();
                return false;
            }

            var birthday = document.getElementById("birthday").value;
            if (birthday == "") {
                alert("�������������...");
                document.getElementById("birthday").focus();
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
                   ѧ�ţ�</td>
                    <td width="650px;">
                         <input id="studentNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧ�ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧ��������</td>
                    <td width="650px;">
                         <input id="studentName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧ��������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ա�</td>
                    <td width="650px;">
                         <input id="sex" type="text"   style="width:20px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������Ա�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ���ڰ༶��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="classInfo" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="birthday"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������ò��</td>
                    <td width="650px;">
                         <input id="zhengzhimianmao" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ͥ��ַ��</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnStudent_Save" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnStudent_Save_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

