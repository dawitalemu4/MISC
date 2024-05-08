<?php ?>

<h2>Inquiries Submission List</h2>
<table class="wp-list-table widefat fixed striped" style="width:98%;">
    <thead>
        <tr>
            <th>ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email Address</th>
            <th>Phone Number</th>
            <th>Campus</th>
            <th>Workshop</th>
            <th>Submitted On</th>
            <th>Completed</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody>
        <?php foreach ($inquiries as $inquiry) : ?>
            <tr>
                <td><?php echo $inquiry->id; ?></td>
                <td><?php echo esc_html($inquiry->firstName); ?></td>
                <td><?php echo esc_html($inquiry->lastName); ?></td>
                <td><?php echo esc_html($inquiry->email); ?></td>
                <td><?php echo esc_html($inquiry->phone); ?></td>
                <td><?php echo esc_html($inquiry->campus); ?></td>
                <td><?php echo esc_html($inquiry->workshop); ?></td>
                <td><?php echo esc_html($inquiry->submitted_date); ?></td>
                <td><?php echo (esc_html($inquiry->completed) === '1' ? 'Yes' : 'No'); ?></td>
                <td>
                    <a href="<?= esc_url(add_query_arg('edit', $inquiry->id, menu_page_url('sample_inquiries', false))); ?>">Edit</a>
                </td>
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>