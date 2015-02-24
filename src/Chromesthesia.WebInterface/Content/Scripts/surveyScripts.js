$(document).ready(function () {

    var numOfTracks = tracks.length;
    var trackId = Math.floor(Math.random() * numOfTracks);
    var paused = true;

    $('#start').mousedown(function () {
        $(this).css("border-bottom", "3px solid #ccddff");
        $(this).css("border-top-width", "2px solid #5566dd");
        $(this).css("background-color", "#aabbee");
    });

    $('#start').mouseup(function () {
        $(this).css("border-bottom", "1px solid #2233aa");
        $(this).css("border-top", "3px solid #ccddff");
        $(this).css("background-color", "#5566dd");
        play();
    });

    $('#start').hover(function () {
        $(this).animate({ "border-bottom-width": "2px", "border-top-width": "4px" }, 10);
    }, function () {
        $(this).animate({ "border-bottom-width": "1px", "border-top-width": "3px" }, 10);
    });

    $('#playPause').click(function () {
        if (paused) { play(); }
        else { pause(); }
    });

    $('#skip').click(function () {
        trackId = iterate(trackId, numOfTracks);
        if (!paused) {
            playTrack(trackId);
        }
    });

    $('.colour').click(function () {
        $(this).animate({ "border-width": "5px" }, 100, function() {
            $(this).animate({ "border-width": "2px" }, 200);
        });
        var colour = $(this).css("background-color");
        saveResult(trackId, colour);
        trackId = iterate(trackId, numOfTracks);
        playTrack(trackId);
    });

    $('.colour').hover(function () {
        $(this).animate({ "border-width": "2px" }, 50);
    }, function () {
        $(this).animate({ "border-width": "0" }, 100);
    });

    function play() {
        $("#playPause").attr("src", "content/Images/pause.png");
        $("#introBackground").animate({ "top": "-50%" }, 200, function () {
            $("#intro").hide();
        });
        playTrack(trackId);
        paused = false;
    }

    function pause() {
        $("#playPause").attr("src", "content/Images/play.png");
        $("#intro").show();
        $("#introBackground").animate({ "top": "50%" }, 200);
        var $newSource = '<source id="audioSource" src="" type="audio/mp3"/>';
        $("#audioSource").replaceWith($newSource);
        $("audio").load();
        paused = true;
    }

    function playTrack(id) {
        var $source = tracks[id];
        var $newSource = '<source id="audioSource" src="Content/Clips/' + $source + '.mp3" type="audio/mp3"/>';
        $("#audioSource").replaceWith($newSource);
        $("audio").load();
    }

    function iterate(id, maxVal) {
        id++;
        if (id >= maxVal) {
            id = 0;
        }
        return id;
    }

    function saveResult(id, colourString) {

        Parse.initialize("LSqmQRHWpRXDusXRfFAPILmeMHBLabJ6KU7LeqJg", "ODK19A7OXkHtv68jqha46B2VwqSddRXxVLMcenlT");
        var Opinion = Parse.Object.extend("Opinion");
        var opinion = new Opinion();

        var rgb = colourString.substring(colourString.indexOf('(') + 1, colourString.lastIndexOf(')')).split(/,\s*/);
        opinion.save({ TrackId: id, TrackString: tracks[id], Colour: colourString, Redness: parseInt(rgb[0]), Greenness: parseInt(rgb[1]), Blueness: parseInt(rgb[2]) });
    }

});

var tracks = ["50 Cent - In Da Club",
    "Alexisonfire - Boiled Frogs",
    "Aphex Twin - Windowlicker",
    "Bellowhead - London Town",
    "Billie Holiday - Come Rain Or Come Shine",
    "Bob Dylan - Mr Tambourine Man",
    "Calvin Harris - Blame",
    "Charles Loir - Danse Macabre ",
    "City And Colour - Comin' Home",
    "Daft Punk - Around The World",
    "Deadmau5 - Ghosts 'n' Stuff",
    "Eminem - Lose Yourself",
    "Fleet Foxes - Meadowlarks",
    "Frank Sinatra - Fly Me to the Moon (in Other Words)",
    "George Gershwin - Rhapsody In Blue",
    "Guns N' Roses - Sweet Child O' Mine",
    "Joe Dolce - Shaddap You Face",
    "Johnny Cash - Folsom Prison Blues",
    "Justin Bieber - Baby",
    "La Reverdie - La quarte estampie royal",
    "Lakme - The Flower Duet",
    "London Philharmonic Orchestra - Peter and the Wolf",
    "Los Campesinos! - What Death Leaves Behind",
    "Ludwig van Beethoven - Fur Elise",
    "Madness - One Step Beyond",
    "Metallica - Enter Sandman",
    "Michael Buble - It's Beginning To Look A Lot Like Christmas",
    "Miles Davis - All Blues",
    "O-Zone - Dragostea din tei",
    "Prince - Purple Rain",
    "Rage Against The Machine - Killing In The Name",
    "Rammstein - DU HAST",
    "Ravi Shankar - Swara-Kakali",
    "Salif Keita - Djembe",
    "Scott Joplin - The Entertainer",
    "Sex Pistols - Anarchy In The UK",
    "Skrillex - Scary Monsters And Nice Sprites",
    "Stevie Wonder - Living For The City",
    "T-Ara - Keep Out",
    "Tarkan - Simarik",
    "Taylor Swift - Love Story",
    "The Barbershop Singers - Hello My Baby",
    "The Beijing Players - Melody for Zhong Hu",
    "The Chemical Brothers - Galvanize",
    "The Northquest Players - Mi Reinita Hechicera",
    "The Wailers - Get Up, Stand Up",
    "The Who - Won't Get Fooled Again",
    "Vampire Weekend - A-Punk",
    "Venetian Snares - Plunging Hornets"];