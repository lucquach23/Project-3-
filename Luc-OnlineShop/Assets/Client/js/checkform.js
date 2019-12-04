function check() {
	var ok = false;
	var nn = document.getElementById('nguoinhan').value;
	if (nn == "" || nn.length > 30) {
		alert("Tên người nhận không hợp lệ");
		document.getElementById('nguoinhan').value == "";
		document.getElementById('nguoinhan').focus();
	} else { ok = true; }


	var dc = document.getElementById('diachi').value;
	if (dc == "" || dc.length > 30) {
		alert("Địa chỉ không hợp lệ");
	} else { ok = true; }



	var re = /(\+84|0)\d{9,10}/;
	var p = document.getElementById("dienthoai").value;

	if (!re.test(p)) {
		alert("Định dạng số điện thoại không hợp lệ");

	} else { ok = true; }



	var mail = document.getElementById('emaicus').value;
	var remail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	if (!remail.test(mail)) {
		alert("Email không hợp lệ");
	} else { ok = true; }
	
	if(ok==true)
	{
		alert("Thông tin hợp lệ, mời tiến hành đặt hàng!");
		document.getElementById('dhn').removeAttribute("disabled");
	}
}
