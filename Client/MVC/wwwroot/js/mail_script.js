
    document.addEventListener("DOMContentLoaded", function () {
        document.querySelectorAll('.sendform').forEach(form => {
            form.addEventListener('submit', function (event) {
                event.preventDefault();

                const email = form.querySelector('.email').value;
                const subject = form.querySelector('.subject').value;
                const message = form.querySelector('.message').value;

                const formData = {
                    Email: email,
                    Subject: subject,
                    Body: message
                };

                fetch("/Subscriber/SendEmail", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(formData)
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            Swal.fire({
                                position: "top-center",
                                icon: "success",
                                title: "Mesajınız başarıyla gönderildi!",
                                showConfirmButton: false,
                                timer: 1500
                            });
                        } else {
                            Swal.fire({
                                title: "Hata!",
                                icon: "error",
                                text: "Gönderim başarısız oldu."
                            });
                        }
                    })
                    .catch(error => {
                        console.error('Something went wrong', error);
                        Swal.fire({
                            position: "top-center",
                            title: "Error!",
                            text: "Bir hata oluştu.",
                            icon: "error",
                            showConfirmButton: true,
                            timer: 1500
                        });
                    });
            });
        });
        });