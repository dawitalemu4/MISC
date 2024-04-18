<?php
    $showForm = true;
    $isFormValid = true;
    $textboxError = "Textbox field is required"; 
    $dropdownError = "";

    $firstName = $lastName = $email = $phone = $campus = $workshop = "";
    $firstNameError = $lastNameError = $emailError = $phoneError = "";
    $textboxErrorArray = [$firstNameError, $lastNameError, $emailError, $phoneError];

    $conn = mysqli_connect("localhost", "user", "password", "database");
    if (!$conn) {
     die("Connection failed: " . mysqli_connect_error());
    }

    if (isset($_POST["submit"])) {
        $firstName=$_POST["firstName"];
        $lastName=$_POST["lastName"];
        $email=$_POST["email"];
        $phone=$_POST["phone"];
        $campus=$_POST["campus"];
        $workshop=$_POST["workshop"];
        $textboxDataArray = [$firstName, $lastName, $email, $phone];

        for ($i = 0; $i < count($textboxDataArray); $i++) {
            if (strlen(trim($textboxDataArray[$i])) === 0) {
                $textboxErrorArray[$i] = $textboxError;
            }
        } 

        if (preg_match('/^.+@.+\..+$/', $email)) {
            $emailError = "Invalid email format.";
            $isFormValid = false;
        }

        if (strlen(trim($campus)) === 0) {
            $dropdownError = "Please select an option";
            $isFormValid = false;
        }
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Request Info</title>
        <link rel="stylesheet" href="info-request.css">
    </head>
    <body>
        <div style="display: flex;">
            <h1>Request Info</h1>
        </div>
        <?php if ($showForm): ?>
            <iframe name="hidden_iframe" id="hidden_iframe" style="display:none;"></iframe>
            <form action="<?php echo $_SERVER["PHP_SELF"]?>" method="POST" target="hidden_iframe">
                <fieldset>
                    <legend class="Legend">Form Info</legend>
                    <input type="text" placeholder="First Name" name="firstName" value="<?php echo $firstName; ?>">
                    <span><?php echo $firstNameError; ?></span>
                    <input type="text" placeholder="Last Name" name="lastName" value="<?php echo $lastName; ?>">
                    <span><?php echo $lastNameError; ?></span>
                    <input type="text" placeholder="Email" name="email" value="<?php echo $email; ?>">
                    <span><?php echo $emailError; ?></span>
                    <input type="tel" placeholder="Phone: 123-456-7890" name="phone" value="<?php echo $phone; ?>" pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}">
                    <span><?php echo $phoneError; ?></span>
                    <label for="campus">Which campus are you interested in?<span>*</span></label>
                    <select name="campus" value="<?php echo $campus; ?>">
                        <option value="">Select a campus</option>
                        <option value="Main Campus">Main Campus</option>
                        <option value="North Campus">North Campus</option>
                        <option value="South Campus">South Campus</option>
                    </select>
                    <span><?php echo $dropdownError; ?></span>
                    <label for="workshop">Which workshop would you like to learn more about?</label>
                    <input type="text" placeholder="Workshop" name="workshop" value="<?php echo $workshop; ?>">
                </fieldset>
                <button type="submit" name="submit">Submit Form</button>
                <button type="reset">Reset Form</button>
            </form>
        <?php else: 
            if ($isFormValid) {

                $showForm = false;

                $stmt = $conn->prepare("INSERT INTO users (first_name, last_name, email, phone, campus, workshop) VALUES (?, ?, ?, ?, ?, ?)");
                $stmt->bind_param("ssssss", $firstName, $lastName, $email, $phone, $campus, $workshop);
                $stmt->execute();

                echo " Thank you for your interest in our workshops! A member of our team will reach out soon. ";
            }
            endif
        ?>
        <footer>&copy; Copyright 2024. Dawit Alemu.</footer>
        <!-- Dawit Alemu -->
        <!-- https://replit.com/@dalemu2/Assignment-2#order.php -->
    </body>
</html>
