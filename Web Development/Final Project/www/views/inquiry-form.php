<?php

    $isFormValid = true;
    $firstNameError = $lastNameError = $emailError = $phoneError = $campusError = '';

    if (count($_POST) > 0) {

        if (empty($_POST['firstName'])) {
            $firstNameError = 'First name is required.';
            $isFormValid = false;
        }

        if (empty($_POST['lastName'])) {
            $lastNameError = 'Last name is required.';
            $isFormValid = false;
        }

        if (empty($_POST['email'])) {
            $emailError = 'Email is required.';
            $isFormValid = false;
        } elseif (!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) {
            $emailError = 'Invalid email format.';
            $isFormValid = false;
        }

        if (empty($_POST['phone'])) {
            $phoneError = 'Phone is required.';
            $isFormValid = false;
        }

        if (empty($_POST['campus'])) {
            $campusError = 'Please select a campus.';
            $isFormValid = false;
        }
    }
?>
<div class="example-inquiry-form">

    <?php if (isset($success) && $success): ?>
        <h2 class="success">Thank you for your inquiry!</h2>
    <?php else: ?>

    <h2>Request Information</h2>
    <p>Fill out the form below and one of our admissions counselors will contact you with more information.</p>

    <form method="post" action="" class="form-container">
        <div>
            <label for="firstName">First Name <span>*</span></label>
            <input type="text" name="firstName" placeholder="First Name" value="<?= $_POST['firstName'] ?? ''; ?>">
            <span><?php echo $firstNameError ?? ''; ?></span>
        </div>

        <div>
            <label for="lastName">Last Name <span>*</span></label>
            <input type="text" name="lastName" placeholder="Last Name" value="<?= $_POST['lastName'] ?? ''; ?>">
            <span><?php echo $lastNameError ?? ''; ?></span>
        </div>

        <div>
            <label for="email">Email <span>*</span></label>
            <input type="text" name="email" placeholder="Email" value="<?= $_POST['email'] ?? ''; ?>">
            <span><?php echo $emailError ?? ''; ?></span>
        </div>

        <div>
            <label for="phone">Phone Number <span>*</span></label>
            <input type="text" name="phone" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" placeholder="Phone Number Ex: 1234567890" value="<?= $_POST['phone'] ?? ''; ?>" >
            <span><?php echo $phoneError ?? ''; ?></span>
        </div>

        <div>
            <label for="campus">Which campus are interesting in? <span>*</span></label>
            <select name="campus">
                <?php $selectedCampus = $_POST['campus'] ?? ''; ?>
                <option value="">Please select...</option>
                <option value='Summit View Academy' <?= ($selectedCampus === 'Summit View Academy') ? 'selected' : ''; ?>>Summit View Academy</option>
                <option value='Crestwood Institute' <?= ($selectedCampus === 'Crestwood Institute') ? 'selected' : ''; ?>>Crestwood Institute</option>
                <option value='Pine Hill College' <?= ($selectedCampus === 'Pine Hill College') ? 'selected' : ''; ?>>Pine Hill College</option>
                <option value='Blue Ridge Campus' <?= ($selectedCampus === 'Blue Ridge Campus') ? 'selected' : ''; ?>>Blue Ridge Campus</option>
                <option value='Starlight Campus' <?= ($selectedCampus === 'Starlight Campus') ? 'selected' : ''; ?>>Starlight Campus</option>
            </select>
            <span><?php echo $campusError ?? ''; ?></span>
        </div>

        <div>
            <label for="workshop">Which workshop would you like to learn about?</label>
            <input type="text" name="workshop" placeholder="Workshop" value="<?= $_POST['workshop'] ?? ''; ?>">
        </div>

        <div id="submit-container">
            <input type="submit" name="submit_inquiry" value="Submit Inquiry">
            <input type="reset" value="Reset">
        </div>
    </form>
    <?php endif ?>
</div>