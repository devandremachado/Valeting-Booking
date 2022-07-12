var Home = (function () {
    const boxHome = $('#Home');
    const tblBookings = boxHome.find('#tblBookings');

    const fields = {
        btnCreateBooking: boxHome.find('#btnCreateBooking')
    }

    $(document).ready(function () {
        Utility.ConfigureDataTable(tblBookings);
        GetAllBookings();
        BtnApproveBookingClickEvent();
        BtnRemoveBookingClickEvent();
        BtnEditBookingClickEvent();
        BtnCreateBookingClickEvent();
    });

    function GetAllBookings() {

        Utility.ClearDataTable(tblBookings);
        Utility.BlockUI();

        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: Booking_Actions.GetAllBookings,
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {

                    if (data.isSucces) {
                        $.each(data.result, function (i, v) {
                            tblBookings.find('tbody').append(`
                                <tr data-externalId="${v.externalId}">
                                    <td class="${v.isApproved ? 'approved' : ''}" >${v.customer.name}</td>
                                    <td class="${v.isApproved ? 'approved' : ''}" >${v.bookingDateFormat}</td>
                                    <td class="${v.isApproved ? 'approved' : ''}" >${Utility.CamelCaseFormatWithSpaces(v.flexibilityDescription)}</td>
                                    <td class="${v.isApproved ? 'approved' : ''}" >${v.vehicleSizeDescription}</td>
                                    <td class="${v.isApproved ? 'approved' : ''}" >${v.customer.phone}</td>
                                    <td class="${v.isApproved ? 'approved' : ''}" >${v.customer.email}</td>
                                    <td class="tabela-acoes">
                                        <button class="btn btn-acao btn-aprovar"></button>
                                        <button class="btn btn-acao btn-reprovar"></button>
                                        <button class="btn btn-acao btn-editar"></button>
                                    </td>
                                </tr>
                            `);
                        });
                    }

                    Utility.ConfigureDataTable(tblBookings, true, true);
                    resolve();
                },
                error: function (erro) {
                    Utility.ModalMessage.Error();
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }

    function ApproveBooking(externalId) {

        const data = {
            'ExternalId': externalId
        };

        Utility.BlockUI();

        return new Promise((resolve, reject) => {
            $.ajax({
                url: Booking_Actions.ApproveBooking,
                type: 'PATCH',
                dataType: 'json',
                async: true,
                data: data,
                success: function (data) {

                    if (data.isSucces) {
                        PaintTableRowToApproved(externalId);
                        Utility.ModalMessage.Sucess(`Booking successfully approved`);
                    }
                    else
                        Utility.ModalMessage.Error(`This booking could not be approved`);

                    resolve();
                },
                error: function (erro) {
                    Utility.ModalMessage.Error();
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }

    function RemoveBooking(externalId) {

        const data = {
            'ExternalId': externalId
        };

        Utility.BlockUI();

        return new Promise((resolve, reject) => {
            $.ajax({
                url: Booking_Actions.RemoveBooking,
                type: 'DELETE',
                dataType: 'json',
                async: true,
                data: data,
                success: function (data) {

                    RemoveRowFromTable(externalId);
                    Utility.ModalMessage.Sucess(`Booking successfully removed`);

                    resolve();
                },
                error: function (erro) {
                    Utility.ModalMessage.Error();
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }

    function BtnApproveBookingClickEvent() {
        tblBookings.find('tbody').on('click', '.btn-aprovar', function () {
            const externalId = $(this).closest('tr').attr('data-externalId');

            if (externalId) {
                Utility.ModalMessage.RequestConformation({
                    message: 'Do you want to approve this booking?',
                    confirmationCallback: () => ApproveBooking(externalId)
                });
            }
        });
    }

    function BtnRemoveBookingClickEvent() {
        tblBookings.find('tbody').on('click', '.btn-reprovar', function () {
            const externalId = $(this).closest('tr').attr('data-externalId');

            if (externalId) {
                Utility.ModalMessage.RequestConformation({
                    message: 'Do you want to delete this booking?',
                    confirmationCallback: () => RemoveBooking(externalId)
                });
            }
        });
    }

    function BtnEditBookingClickEvent() {
        tblBookings.find('tbody').on('click', '.btn-editar', function () {
            const externalId = $(this).closest('tr').attr('data-externalId');

            Utility.ModalMessage.Information('Not implemented...');
        });
    }

    function BtnCreateBookingClickEvent() {

        fields.btnCreateBooking.on('click', function () {
            Utility.ModalMessage.Information('Not implemented...');
        });
    }

    function PaintTableRowToApproved(externalId) {
        const row = tblBookings.find(`tbody tr[data-externalId='${externalId}']`);
        const fields = row.find('td').not('.tabela-acoes');

        $.each(fields, function (i, v) {
            $(v).addClass('approved');
        });
    }

    function RemoveRowFromTable(externalId) {
        const row = tblBookings.find(`tbody tr[data-externalId='${externalId}']`);
        row.remove();
    }

})();