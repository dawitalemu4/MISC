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

if (isset($inquiry)): ?>
    <div class="wrap">
        <h1>Edit Inquiry</h1>
        <form method="post" action="<?php echo esc_url(admin_url('admin-post.php')); ?>" class="form-container">
            <div>
                <input type="hidden" name="action" value="handle_inquiry_update">
                <input type="hidden" name="inquiry_id" value="<?php echo intval($inquiry->id); ?>">
            </div>

            <div>
                <label for="firstName">First Name <span>*</span></label>
                <input type="text" name="firstName" placeholder="First Name" value="<?php echo esc_attr($inquiry->firstName); ?>">
                <span><?php echo $firstNameError ?? ''; ?></span>
            </div>

            <div>
                <label for="lastName">Last Name <span>*</span></label>
                <input type="text" name="lastName" placeholder="Last Name" value="<?php echo esc_attr($inquiry->lastName); ?>">
                <span><?php echo $lastNameError ?? ''; ?></span>
            </div>

            <div>
                <label for="email">Email <span>*</span></label>
                <input type="text" name="email" placeholder="Email" value="<?php echo esc_attr($inquiry->email); ?>">
                <span><?php echo $emailError ?? ''; ?></span>
            </div>

            <div>
                <label for="phone">Phone Number <span>*</span></label>
                <input type="text" name="phone" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" placeholder="Phone Number Ex: 1234567890" value="<?php echo esc_attr($inquiry->phone); ?>">
                <span><?php echo $phoneError ?? ''; ?></span>
            </div>

            <div>
                <label for="campus">Which campus are interesting in? <span>*</span></label>
                <select name="campus">
                    <option value="">Please select...</option>
                    <option value='Summit View Academy' <?= (esc_attr($inquiry->campus) === 'Summit View Academy') ? 'selected' : ''; ?>>Summit View Academy</option>
                    <option value='Crestwood Institute' <?= (esc_attr($inquiry->campus) === 'Crestwood Institute') ? 'selected' : ''; ?>>Crestwood Institute</option>
                    <option value='Pine Hill College' <?= (esc_attr($inquiry->campus) === 'Pine Hill College') ? 'selected' : ''; ?>>Pine Hill College</option>
                    <option value='Blue Ridge Campus' <?= (esc_attr($inquiry->campus) === 'Blue Ridge Campus') ? 'selected' : ''; ?>>Blue Ridge Campus</option>
                    <option value='Starlight Campus' <?= (esc_attr($inquiry->campus) === 'Starlight Campus') ? 'selected' : ''; ?>>Starlight Campus</option>
                </select>
                <span><?php echo $campusError ?? ''; ?></span>
            </div>

            <div>
                <label for="workshop">Which workshop would you like to learn about?</label>
                <input type="text" name="workshop" placeholder="Workshop" value="<?php echo esc_attr($inquiry->workshop); ?>">
            </div>

            <div>
                <label for="completed">Completed</label>
                <input type="checkbox" name="completed" <?= (esc_attr($inquiry->completed) === '1') ? 'checked' : ''; ?>>                
            </div>

            <div>
                <input type="submit" value="Update Inquiry" class="button-primary">
            </div>
        </form>

        <form method="post" action="<?php echo esc_url(admin_url('admin-post.php')); ?>" class="form-container">
            <input type="hidden" name="action" value="handle_inquiry_delete">
            <input type="hidden" name="inquiry_id" value="<?php echo intval($inquiry->id); ?>">
            <div>
                <input type="submit" value="Delete Inquiry" class="button-primary" style="background-color:red;">
            </div>
        </form>
    </div>
<?php endif; ?>