<?php
// Function to handle form submission.
function handle_inquiry_submission() {

    if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['submit_inquiry'])) { // Check if form is submitted

        global $wpdb; // Global variable for WordPress database interaction

        $table_name = $wpdb->prefix . 'inquiry_request_table'; // Prefix the table name with the WordPress prefix

        // Sanitize and validate form data
        $firstName = sanitize_text_field($_POST['firstName']);
        $lastName = sanitize_text_field($_POST['lastName']);
        $email = sanitize_email($_POST['email']);
        $phone = sanitize_text_field($_POST['phone']);
        $campus = sanitize_text_field($_POST['campus']);
        $workshop = sanitize_text_field($_POST['workshop']);

        // Check if all fields are filled and email is valid
        if (!empty($firstName) && !empty($lastName) && is_email($email) && !empty($phone) && !empty($campus)) {
            // Insert data into database
            $wpdb->insert($table_name, array(
                'firstName' => $firstName,
                'lastName' => $lastName,
                'email' => $email,
                'phone' => $phone,
                'campus' => $campus,
                'workshop' => $workshop,
            ));

            $to = $email;
            $subject = 'Inquiry Submission Confirmation';
            $message = "Thank you for your inquiry. We will get back to you soon." .
            "\nName: " . $firstName . " " . $lastName .
            "\nEmail: " . $email .
            "\nPhone: " . $phone .
            "\nCampus: " . $campus .
            "\nWorkshop: " . $workshop;

            wp_mail($to, $subject, $message);
            
            return true; // Return true if submission is successful
        }

        return false; // Return false if validation fails
    }
}


// Function to handle form/inquiry update by admin. This function will be called when the form is updated by admin.
function handle_inquiry_update() {

    // Check if the current user has the 'manage_options' capability
    if (!current_user_can('manage_options')) {
        // If the user does not have the 'manage_options' capability, stop execution and display an error
        wp_die('You are not allowed to edit this item.');
    }

    // Check for POST request
    if ('POST' !== $_SERVER['REQUEST_METHOD']) {
        wp_die('Invalid request method.');
    }

    global $wpdb;
    $table_name = $wpdb->prefix . 'inquiry_request_table';

    // Assuming data is validated and sanitized because it is editable only by admins, we do not need to re-validate/sanitize here.
    $firstName = sanitize_text_field($_POST['firstName']);
    $lastName = sanitize_text_field($_POST['lastName']);
    $email = sanitize_email($_POST['email']);
    $phone = sanitize_text_field($_POST['phone']);
    $campus = sanitize_text_field($_POST['campus']);
    $workshop = sanitize_text_field($_POST['workshop']);
    $inquiry_id = intval($_POST['inquiry_id']);

    if ($_POST['completed']) {
        $completed = intval(1);
    } else {
        $completed = intval(0);
    }

    // Check that required fields are not empty
    if (!empty($firstName) && !empty($lastName) && is_email($email) && !empty($phone) && !empty($campus)) {
        $wpdb->update($table_name, array(
            'firstName' => $firstName,
            'lastName' => $lastName,
            'email' => $email,
            'phone' => $phone,
            'campus' => $campus,
            'workshop' => $workshop,
            'completed' => $completed,
        ), ['id' => $inquiry_id]);
    } else {
        // Redirect back to the edit page if any field is empty with an error message
        wp_redirect(add_query_arg([
            'page' => 'custom_inquiries', // Page slug
            'edit' => $inquiry_id,    // Query arg for the inquiry ID
            'error' => 'empty_fields' // Query arg for error message
        ], admin_url('admin.php')));
        exit;
    }

    // Redirect back to the list page with a success message
    wp_redirect(add_query_arg([
        'page' => 'custom_inquiries', // Page slug
        'updated' => 'true'           // Query arg for success message
    ], admin_url('admin.php')));      // Redirect to the admin page
    exit;
}

// Register the admin post action for form submission
add_action('admin_post_handle_inquiry_update', 'handle_inquiry_update');


// Function to handle form/inquiry delete by admin. This function will be called when the form is updated by admin.
function handle_inquiry_delete() {

    // Check if the current user has the 'manage_options' capability
    if (!current_user_can('manage_options')) {
        // If the user does not have the 'manage_options' capability, stop execution and display an error
        wp_die('You are not allowed to edit this item.');
    }

    // Check for POST request
    if ('POST' !== $_SERVER['REQUEST_METHOD']) {
        wp_die('Invalid request method.');
    }

    global $wpdb;
    $table_name = $wpdb->prefix . 'inquiry_request_table';

    $inquiry_id = intval($_POST['inquiry_id']);

    // Check that required fields are not empty
    if (!empty($inquiry_id)) {
        $wpdb->delete($table_name, array('id' => $inquiry_id));
    }

    // Redirect back to the list page with a success message
    wp_redirect(add_query_arg([
        'page' => 'custom_inquiries', // Page slug
        'updated' => 'true'           // Query arg for success message
    ], admin_url('admin.php')));      // Redirect to the admin page
    exit;
}

// Register the admin post action for form submission
add_action('admin_post_handle_inquiry_delete', 'handle_inquiry_delete');