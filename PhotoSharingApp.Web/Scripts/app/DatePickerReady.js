if (!Modernizr.inputtypes.date) {
    $(function () { // will trigger when the document is ready
        $(".datepicker").datepicker({
            startDate: '-20y',
            format: "dd/mm/yyyy",
            language: "es"
            
        });
    });
}