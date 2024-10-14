﻿$(document).ready(function () {
    $.noConflict();

    // Check if DataTable is already initialized and destroy it if necessary
    if ($.fn.DataTable.isDataTable('#classTable')) {
        $('#classTable').DataTable().destroy();
    }
    loadTable();
});

function saveClass() {

    if (!validateForm()) {
        return; // Stop execution if validation fails
    }

    var id = $('#classId').val();
    var className = $('#className').val();
    var teacherName = $('#teacherName').val();
    var numberOfStudents = $('#numberOfStudents').val();
    var startDate = $('#startDate').val();
    var endDate = $('#endDate').val();
    var isActive = $('#isActive').is(':checked');

    var studentclass = {
        id: id,
        name: className,
        teacherName: teacherName,
        numberOfStudents: numberOfStudents,
        startDate: startDate,
        endDate: endDate,
        isActive: isActive
    };

    var url = '/class/create'; // Adjust URL as needed

    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(studentclass),
        success: function (response) {
            swal("Success", "Class saved successfully!", "success");
            clearClass();
            loadTable(); // Refresh the table after saving
            location.reload();
        },
        error: function (err) {
            console.error('Error saving class:', err);
        }
    });
}


function validateForm() {
    var className = $('#className').val().trim();
    var teacherName = $('#teacherName').val().trim();
    var numberOfStudents = $('#numberOfStudents').val().trim();
    var startDate = $('#startDate').val().trim();
    var endDate = $('#endDate').val().trim();

    if (!className) {
        swal("Validation Error", "Class Name is required!", "error");
        return false;
    }
    if (!teacherName) {
        swal("Validation Error", "Teacher Name is required!", "error");
        return false;
    }
    if (!numberOfStudents || isNaN(numberOfStudents) || numberOfStudents <= 0) {
        swal("Validation Error", "Number of Students must be a positive number!", "error");
        return false;
    }
    if (!startDate) {
        swal("Validation Error", "Start Date is required!", "error");
        return false;
    }
    if (!endDate) {
        swal("Validation Error", "End Date is required!", "error");
        return false;
    }
    if (new Date(startDate) > new Date(endDate)) {
        swal("Validation Error", "End Date must be after Start Date!", "error");
        return false;
    }

    return true;
}



function loadTable() {
    $.ajax({
        url: '/class/getall',
        type: 'GET',
        success: function (response) {
            var tbody = $('#tbodyid');
            tbody.empty(); // Clear the table body

            response.forEach(function (studentclass) {
                var row = `<tr>
                    <td hidden>${studentclass.id}</td>
                    <td>${studentclass.name}</td>
                    <td>${studentclass.teacherName}</td>
                    <td>${studentclass.numberOfStudents}</td>
                    <td>${formatDate(studentclass.startDate)}</td>
                    <td>${formatDate(studentclass.endDate)}</td>
                    <td>${studentclass.isActive ? 'No' : 'Yes'}</td>
                    <td><button class="btn btn-warning" onclick="getClass(${studentclass.id})">Edit</button></td>
                    <td><button class="btn btn-danger" onclick="deleteClass(${studentclass.id})">Delete</button></td>
                </tr>`;
                tbody.append(row);
            });

            // Initialize DataTables with export buttons after all rows have been appended
            if ($.fn.DataTable.isDataTable('#classTable')) {
                $('#classTable').DataTable().destroy(); // Destroy previous instance if exists
            }

            $('#classTable').DataTable({
                destroy: true,
                searching: true, // Enable search functionality
                paging: true, // Enable pagination
                pageLength: 10, // Number of rows per page
                lengthMenu: [5, 10, 20, 50], // Options for rows per page
                info: true, // Show table information
                language: {
                    search: "Search records:", // Custom search placeholder
                    paginate: {
                        previous: "Prev",
                        next: "Next"
                    }
                },
                dom: 'Bfrtip', // Include export buttons
                buttons: [
                    {
                        extend: 'csvHtml5',
                        text: 'Export CSV',
                        titleAttr: 'CSV',
                        className: 'btn btn-success',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6] // Select specific columns to export
                        }
                    },
                    {
                        extend: 'excelHtml5',
                        text: 'Export Excel',
                        titleAttr: 'Excel',
                        className: 'btn btn-primary',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6] // Select specific columns to export
                        }
                    },
                    {
                        extend: 'pdfHtml5',
                        text: 'Export PDF',
                        titleAttr: 'PDF',
                        className: 'btn btn-danger',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6] // Select specific columns to export
                        }
                    },
                    {
                        extend: 'print',
                        text: 'Print',
                        titleAttr: 'Print',
                        className: 'btn btn-info',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6] // Select specific columns to export
                        }
                    }
                ]
            });
        },
        error: function (err) {
            console.error('Error loading table:', err);
        }
    });
}

function getClass(courseId) {
    $.ajax({
        url: '/class/get/' + courseId,
        type: 'GET',
        success: function (response) {
            $('#classId').val(response.id);
            $('#className').val(response.name);
            $('#teacherName').val(response.teacherName);
            $('#numberOfStudents').val(response.numberOfStudents);
            $('#startDate').val(formatDate(response.startDate));
            $('#endDate').val(formatDate(response.endDate));
            $('#isActive').prop('checked', response.isActive);
        },
        error: function (err) {
            console.error('Error fetching class:', err);
        }
    });
}


function formatDate(dateString) {
    if (!dateString) return '';
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
}


function deleteClass(classId) {
    $.ajax({
        url: '/class/delete/' + classId,
        type: 'DELETE',
        success: function (response) {
            swal("Success", "Class deleted successfully!", "success");
            loadTable(); // Refresh the table after deleting
            location.reload();
        },
        error: function (err) {
            console.error('Error deleting class:', err);
        }
    });
}

function clearClass() {
    $('#classId').val('0');
    $('#className').val('');
    $('#teacherName').val('');
    $('#numberOfStudents').val('');
    $('#startDate').val('');
    $('#endDate').val('');
    $('#isActive').prop('checked', true);
}
