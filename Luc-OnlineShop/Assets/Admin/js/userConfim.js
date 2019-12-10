var user = {
	inti: function () {
		user.registerEvents();
	},
	registerEvents: function ()
	{
		$('.btn-active').off('click').on('click', function (e) {
			e.preventDefault();
			var btn = $(this);
			var id = $(this).data('id');
			$.ajax({
				url: "/Admin/DHang/ChangeStatus",
				data: { id: id },
				dataType: "json",
				type: "POST",
				success: function (response) {
					if (response.status == true) {
						btn.text('Đã xác thực');
					} else {
						btn.text('Chưa xác thực');
					}
				}
			});
		});
	}
}
user.inti();