// Initialize and configure DataTable plugin for the table with the id "staff-members-table"
$(document).ready(function () {
    $('#staff-members-table').DataTable({
        // Configure Greek for the DataTable
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/el.json',
        },
        // Enable paging functionality
        paging: true,
        // Enable ordering (sorting) functionality
        ordering: true,
        // Enable display of table information (e.g., "Showing 1 to 10 of 20 entries")
        info: true,
        // Define column-specific settings
        "columnDefs": [
            // Disable ordering for the last three columns (-3, -2, -1)
            { "orderable": false, "targets": [-3, -2, -1] }
        ]
    });
});

// Initialize and configure DataTable plugin for the table with the id "leave-requests-table"
$(document).ready(function () {
    $('#leave-requests-table').DataTable({
        // Configure Greek for the DataTable
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/el.json',
        },
        // Enable paging functionality
        paging: true,
        // Enable ordering (sorting) functionality
        ordering: true,
        // Enable display of table information (e.g., "Showing 1 to 10 of 20 entries")
        info: true,
        // Define column-specific settings
        "columnDefs": [
            // Disable ordering for the last column (-1)
            { "orderable": false, "targets": [-1] }
        ]
    });
});

