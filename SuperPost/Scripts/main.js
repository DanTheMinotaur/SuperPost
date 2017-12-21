
function loadReviews() {
    $.getJSON("api/Reviews", function (data) {

        var table = '<table class="table table-hover"><thead><tr><th>Name</th><th>Comment</th><th>Date Posted</th></tr></thead><tbody>';
        
        $.each(data, function (key, value) {
            //table += value.Name + value.Comment + value.DateTime;
            //console.log(value.ID);
            var date = JSON.stringify(value.DateTime).split('T')[0];
            
            table += '<tr><td>' + value.Name + '</td>';
            table += '<td>' + value.Comment + '</td>';
            table += '<td>' + date + '</td></tr>';
        });
        //console.log(html);
        table += '</tbody></table>';
        console.log(table);
        $('#reviewSpace').html(table);
    });
}

function addReview() {
    $.post('/api/Reviews', $('#addReview').serialize())
        .done(function (data) {
            alert('Review Added!');
        });
}

$(function () {
    console.log("ready!");
    $('#reviewTrigger').click(function () {
        console.log('Clicked review');
        loadReviews();
        //console.log(loadReviews());
    });

    $('#addReview').submit(function (event) {
        event.preventDefault();
        addReview();
    });

    $('#submitComment').click(function (event) {
        loadReviews();
    });
});
