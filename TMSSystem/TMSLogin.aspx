<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="TMSLogin.aspx.cs" Inherits="TMSSystem.TMSLogin" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login V20</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="design/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="design/css/util.css">
    <link rel="stylesheet" type="text/css" href="design/css/main.css">
    <!--===============================================================================================-->
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-b-160 p-t-50">
                <form class="login100-form validate-form" id="form1" runat="server">
                    <span class="login100-form-title p-b-43">Account Login
                    </span>

                    <div class="wrap-input100 rs1 validate-input" data-validate="Username is required">
                        <asp:TextBox ID="Username" class="input100" runat="server"></asp:TextBox>
                        <span class="label-input100">Username</span>
                    </div>


                    <div class="wrap-input100 rs2 validate-input" data-validate="Password is required">
                        <asp:TextBox ID="password" class="input100" runat="server"  TextMode="Password"></asp:TextBox>
                        <span class="label-input100">Password</span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="loginBtn" runat="server" class="login100-form-btn" Text="Sign in" OnClick="Login" />
                    </div>

                    <div class="text-center w-full p-t-23">
                        <asp:Label ID="Label1" runat="server" class="txt1" Text="Label" Visible="False"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!--===============================================================================================-->
    <script src="design/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="design/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="design/vendor/bootstrap/js/popper.js"></script>
    <script src="design/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="design/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="design/vendor/daterangepicker/moment.min.js"></script>
    <script src="design/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="design/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="design/js/main.js"></script>

</body>
</html>