function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function successMessage(message) {
    Notiflix.Report.success(
        'Success!',
        message,
        'Ok',
    );
}

function errorMessage(message) {
    // Swal.fire({
    //     title: "Error!",
    //     text: message,
    //     icon: "error"
    // });

    Notiflix.Report.failure(
        'Error!',
        message,
        'Ok',
    );
}

function testConfirmMessageBox(message) {
    let confirmMessage = new Promise(function (success, error) {
        // Swal.fire({
        //     title: "Confirm",
        //     text: message,
        //     icon: "warning",
        //     showCancelButton: true,
        //     confirmButtonColor: "#3085d6",
        //     cancelButtonColor: "#d33",
        //     confirmButtonText: "Yes, delete it!"
        // }).then((result) => {
        //     if (result.isConfirmed) success();
        //     else error();

        // });
        Notiflix.Confirm.show(
            'Confirm',
            message,
            'Yes',
            'No',
            function okCb() {
                success();
            },
            function cancelCb() {
                error();
            },
            {
            },
        );

    });
    return confirmMessage;
    // confirmMessage.then(
    //   function(value) {
    //      successMessage('Deleting successful');
    //   },
    //   function(error) {
    //     errorMessage('Error');
    //    }
    // );
}
