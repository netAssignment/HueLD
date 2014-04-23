var default_content = "";

$(document).ready(function () {	//executed after the page has loaded

    checkURL();	//check if the URL has a reference to a page and load it

    $('ul li a').click(function (e) {	//traverse through all our navigation links..

        checkURL(this.hash);	//.. and assign them a new onclick event, using their own hash as a parameter (#page1 for example)

    });

    setInterval("checkURL()", 250);	//check for a change in the URL every 250 ms to detect if the history buttons have been used

});

var lasturl = "";	//here we store the current URL hash

function checkURL(hash) {
    if (!hash) hash = window.location.hash;	//if no parameter is provided, use the hash value from the current address

    if (hash != lasturl)	// if the hash value has changed
    {
        lasturl = hash;	//update the current hash
        loadPage(hash);	// and load the new page
    }
}

function loadPage(url)	//the function that loads pages via AJAX
{
    url1 = url.replace('#page', '');	//strip the #page part of the hash and leave only the page number

    $('#loading').css('visibility', 'visible');	//show the rotating gif animation

    $.ajax({
        url: '/index1',
        data: { page: url1 },
        //type: 'POST',
        success: function (data) {
            $('#pageContent').html(data);
            $('#loading').css('visibility', 'hidden');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + " - " + errorThrown);
    }
    });

}