function iletisim_formu() {
    var email = $("#Email").val();
    var adi = $("#Adi").val();
    var soyadi = $("#Soyadi").val();
    var mesaj = $("#Mesaj").val();

    var message = {
        "email": email,
        "adi": adi,
        "soyadi": soyadi,
        "mesaj": mesaj
    };

    $.ajax({
        method: "POST",
        url: "/Home/Contact",
        type: "json",
        data: message,
        success: function (data) {
            document.getElementById("iletisim_formu").reset();
            $("#sonuc").show().html("Mesajýnýz Gönderildi!").delay("5000").fadeOut();
        },
        error: function (err) {
            alert("Hata Oluþtu!");
        }

    });
}