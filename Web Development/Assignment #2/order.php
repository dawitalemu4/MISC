<!DOCTYPE html>
<html lang="en">
    <?php
        if (isset($_POST["submit"])) {
            $billingButton=$_POST["billingButton"];
            $firstName=$_POST["firstName"];
            $lastName=$_POST["lastName"];
            $address=$_POST["address"];
            $city=$_POST["city"];
            $state=$_POST["state"];
            $billingFirstName=$_POST["billingFirstName"];
            $billingLastName=$_POST["billingLastName"];
            $billingAddress=$_POST["billingAddress"];
            $billingCity=$_POST["billingCity"];
            $billingState=$_POST["billingState"];
            $username=$_POST["username"];
            $password=$_POST["password"];
            $confirmedPassword=$_POST["confirmedPassword"];
        
            if ($password !== $confirmedPassword) {
                echo "<script>alert('ensure passwords match'); window.onload = function() { window.location.href = 'order.php'; }</script>";
            }
          
            if (strlen(trim($username)) < 5) {
              echo "<script>alert('username must be 5 characters, try again'); window.onload = function() { window.location.href = 'order.php'; }</script>";
            }

            if ($billingButton == "on") {
                $billingFirstName = $firstName;
                $billingLastName = $lastName;
                $billingAddress = $address;
                $billingCity = $city;
                $billingState = $state;
            } else {
                echo "<script>alert('fill in the billing info'); window.onload = function() { window.location.href = 'order.php'; }</script>";
            }

            echo "First Name: " . $firstName . "<br />" ;
            echo "Last Name: " . $lastName . "<br />" ;
            echo "Address: " . $address . "<br />" ;
            echo "City: " . $city . "<br />" ;
            echo "State: " . $state. "<br />" ;
            echo "Billing First Name: " . $billingFirstName . "<br />" ;
            echo "Billing Last Name: " . $billingLastName . "<br />" ;
            echo "Billing Address: " . $billingAddress . "<br />" ;
            echo "Billing City: " . $billingCity . "<br />" ;
            echo "Billing State: " . $billingState. "<br />" ;
            echo "Username: " . $username . "<br />" ;
            echo "Password: " . $password . "<br />" ;
        } else {
    ?>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Assignment #1: Order Form</title>
        <link rel="stylesheet" href="order.css">
    </head>
    <body>
        <div style="display: flex;">
            <h1>ITEC 464: Assignment #1</h1>
            <img src="https://st3.depositphotos.com/1785730/18182/i/450/depositphotos_181824534-stock-photo-maine-coon-sitting-and-looking.jpg" alt="Logo">
        </div>
        <form action="<?php echo $_SERVER["PHP_SELF"]?>" method="POST">
            <fieldset>
                <legend class="Legend">Personal Info</legend>
                <input type="text" placeholder="First Name" name="firstName" required>
                <input type="text" placeholder="Last Name" name="lastName" required>
                <input type="text" placeholder="Street Address" name="address" required>
                <input type="text" placeholder="City" name="city" required>
                <select name="state">
                    <option value="" disabled>State</option>
                    <option value="AL">AL</option>
                    <option value="AK">AK</option>
                    <option value="AZ">AZ</option>
                    <option value="AR">AR</option>
                    <option value="CA">CA</option>
                    <option value="CO">CO</option>
                    <option value="CT">CT</option>
                    <option value="DE">DE</option>
                    <option value="FL">FL</option>
                    <option value="GA">GA</option>
                    <option value="HI">HI</option>
                    <option value="ID">ID</option>
                    <option value="IL">IL</option>
                    <option value="IN">IN</option>
                    <option value="IA">IA</option>
                    <option value="KS">KS</option>
                    <option value="KY">KY</option>
                    <option value="LA">LA</option>
                    <option value="ME">ME</option>
                    <option value="MD">MD</option>
                    <option value="MA">MA</option>
                    <option value="MI">MI</option>
                    <option value="MN">MN</option>
                    <option value="MS">MS</option>
                    <option value="MO">MO</option>
                    <option value="MT">MT</option>
                    <option value="NE">NE</option>
                    <option value="NV">NV</option>
                    <option value="NH">NH</option>
                    <option value="NJ">NJ</option>
                    <option value="NM">NM</option>
                    <option value="NY">NY</option>
                    <option value="NC">NC</option>
                    <option value="ND">ND</option>
                    <option value="OH">OH</option>
                    <option value="OK">OK</option>
                    <option value="OR">OR</option>
                    <option value="PA">PA</option>
                    <option value="RI">RI</option>
                    <option value="SC">SC</option>
                    <option value="SD">SD</option>
                    <option value="TN">TN</option>
                    <option value="TX">TX</option>
                    <option value="UT">UT</option>
                    <option value="VT">VT</option>
                    <option value="VA">VA</option>
                    <option value="WA">WA</option>
                    <option value="WV">WV</option>
                    <option value="WI">WI</option>
                    <option value="WY">WY</option>
                </select>
            </fieldset>
            <fieldset>
                <legend class="Legend">Payment</legend>
                <div id="RadioButtonContainer">
                    <input name="Visa" type="radio" value="Visa" checked>
                    <label for="Visa">Visa</label>
                    <input name="Discover" type="radio" value="Discover">
                    <label for="Discover">Discover</label>
                    <input name="Mastercard" type="radio" value="Mastercard">
                    <label for="Mastercard">Mastercard</label>
                    <input name="American Express" type="radio" value="American Express">
                    <label for="American Express">American Express</label>
                </div>
                <div>
                    <input type="text" placeholder="Card Number" name="cardNumber" required>
                    <select name="cardMonth">
                        <option value="" disabled>Expiration Month</option>
                        <option value="01">01</option>
                        <option value="02">02</option>
                        <option value="03">03</option>
                        <option value="04">04</option>
                        <option value="05">05</option>
                        <option value="06">06</option>
                        <option value="07">07</option>
                        <option value="08">08</option>
                        <option value="09">09</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                    </select>
                    <select nam="cardYear">
                        <option value="" disabled>Expiration Year</option>
                        <option value="2024">2024</option>
                        <option value="2025">2025</option>
                        <option value="2026">2026</option>
                        <option value="2027">2027</option>
                        <option value="2028">2028</option>
                        <option value="2029">2029</option>
                    </select>
                    <input type="text" placeholder="CVV" name="cardCVV" required>
                </div>
            </fieldset>
            <fieldset>
                <legend class="Legend">Billing Address Info</legend>
                <label for="billingButton" checked>Same as billing address</label>
                <input type="checkbox" name="billingButton" checked>
                  <input type="text" placeholder="First Name" name="billingFirstName">
                  <input type="text" placeholder="Last Name" name="billingLastName">
                  <input type="text" placeholder="Street Address" name="billingAddress">
                  <input type="text" placeholder="City" name="billingCity">
                  <select name="billingState">
                      <option value="" disabled>State</option>
                      <option value="AL">AL</option>
                      <option value="AK">AK</option>
                      <option value="AZ">AZ</option>
                      <option value="AR">AR</option>
                      <option value="CA">CA</option>
                      <option value="CO">CO</option>
                      <option value="CT">CT</option>
                      <option value="DE">DE</option>
                      <option value="FL">FL</option>
                      <option value="GA">GA</option>
                      <option value="HI">HI</option>
                      <option value="ID">ID</option>
                      <option value="IL">IL</option>
                      <option value="IN">IN</option>
                      <option value="IA">IA</option>
                      <option value="KS">KS</option>
                      <option value="KY">KY</option>
                      <option value="LA">LA</option>
                      <option value="ME">ME</option>
                      <option value="MD">MD</option>
                      <option value="MA">MA</option>
                      <option value="MI">MI</option>
                      <option value="MN">MN</option>
                      <option value="MS">MS</option>
                      <option value="MO">MO</option>
                      <option value="MT">MT</option>
                      <option value="NE">NE</option>
                      <option value="NV">NV</option>
                      <option value="NH">NH</option>
                      <option value="NJ">NJ</option>
                      <option value="NM">NM</option>
                      <option value="NY">NY</option>
                      <option value="NC">NC</option>
                      <option value="ND">ND</option>
                      <option value="OH">OH</option>
                      <option value="OK">OK</option>
                      <option value="OR">OR</option>
                      <option value="PA">PA</option>
                      <option value="RI">RI</option>
                      <option value="SC">SC</option>
                      <option value="SD">SD</option>
                      <option value="TN">TN</option>
                      <option value="TX">TX</option>
                      <option value="UT">UT</option>
                      <option value="VT">VT</option>
                      <option value="VA">VA</option>
                      <option value="WA">WA</option>
                      <option value="WV">WV</option>
                      <option value="WI">WI</option>
                      <option value="WY">WY</option>
                  </select>
            </fieldset>
            <fieldset>
                <legend class="Legend">Create Account</legend>
                <input type="text" placeholder="Username" name="username" required>
                <input type="password" placeholder="Password" name="password" required>
                <input type="password" placeholder="Re-type Password" name="confirmedPassword" required>
            </fieldset>
            <button type="submit" name="submit">Place Order</button>
        </form>
        <footer>&copy; Copyright 2024. Dawit Alemu.</footer>
        <!-- Dawit Alemu -->
        <!-- https://replit.com/@dalemu2/Assignment-2#order.php -->
    </body>
    <?php } ?>
</html>