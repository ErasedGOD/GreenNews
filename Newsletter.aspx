<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="GreenTest.Newsletter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divFinalImage" runat="server">

                <img alt="" src="\Images\greenfinch01.gif" class="center" style="align-content: center" />

            </div>
            <div id="divNewsletter" align="center" runat="server">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" value="" placeholder="someone@example.com" onblur="checkEmail(this.value)"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSource" runat="server" Text="How they heard about us:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlSource" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblReason" runat="server" Text="Reason for signing up:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtReason" runat="server" value="" Width="150px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="Validations();" OnClick="Submit_Click" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

<script>
    function checkEmail(str) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!re.test(str)) {
            document.getElementById("btnSubmit").disabled = true;
            document.getElementById("txtEmail").style.border = "1px solid red";
            alert("Please enter a valid email address");
        } else {
            document.getElementById("txtEmail").style.border = "1px solid green";
            document.getElementById("btnSubmit").disabled = false;
        }
    }

    function Validations() {
        var source = document.getElementById("ddlSource").value;
        var email = document.getElementById("txtEmail").value;

        if (email == "") {
            alert('Please fill the email box!');
            return false;
        }

        if (source == "0") {
            alert('Please Fill the field source!');
            return false;
        }

    }
</script>
