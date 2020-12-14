$.validator.addMethod("date", function (value, element) {
    var momentDate = moment(value, 'mm/dd/yyyy');
    return this.optional(element) || !/Invalid|NaN/.test(momentDate.toDate());
});


$.validator.unobtrusive.adapters.addSingleVal("maxwords", "number");

$.validator.addMethod("maxwords", function (value, element, maxwords) {

    if (value) {
        var numberOfWords = value.split(' ').length;

        return numberOfWords <= maxwords

    }

    return true;

});