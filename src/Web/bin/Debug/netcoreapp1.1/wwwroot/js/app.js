try { Typekit.load({ async: true }); } catch (e) { }

$('#sidebar').affix({
    offset: {
        top: 245
    }
});