$(document).ready(function () {

    // See for more teams.
    // http://www.neoseeker.com/forums/76848/t2065660-team-list-for-pes-2015-revealed/

    var premierTeams = [
        'Arsenal',
        'Aston Villa',
        'Burnley',
        'Chelsea',
        'Crystal Palace',
        'Everton',
        'Hull City',
        'Leicester City',
        'Liverpool',
        'Manchester City',
        'Manchester United',
        'Newcastle United',
        'Queens Park Rangers',
        'Southampton',
        'Stoke City',
        'Sunderland',
        'Swansea City',
        'Tottenham Hotspur',
        'West Bromwich Albion',
        'West Ham United'
    ];

    var champonshipTeams = [
        'Birmingham City',
        'Blackburn Rovers',
        'Blackpool',
        'Bolton Wanderers',
        'Bournemouth',
        'Brentford',
        'Brighton & Hove Albion',
        'Cardiff City',
        'Charlton Athletic',
        'Derby County',
        'Fulham',
        'Huddersfield Town',
        'Ipswich Town',
        'Leeds United',
        'Middlesbrough',
        'Millwall',
        'Norwich City',
        'Nottingham Forest',
        'Reading',
        'Rotherham United',
        'Sheffield Wednesday',
        'Watford',
        'Wigan Athletic',
        'Wolverhampton Wanderers'
    ];

    var europeanTeams = [
        'Austria',
        'Belgium',
        'Bosnia and Herzegovina',
        'Bulgaria',
        'Croatia',
        'Czech Republic',
        'Denmark',
        'England',
        'Finland',
        'France',
        'Germany',
        'Greece',
        'Hungary',
        'Ireland',
        'Israel',
        'Italy',
        'Montenegro',
        'Netherlands',
        'Northern Ireland',
        'Norway',
        'Poland',
        'Portugal',
        'Romania',
        'Russia',
        'Scotland',
        'Serbia',
        'Slovakia',
        'Slovenia',
        'Spain',
        'Sweden',
        'Switzerland',
        'Turkey',
        'Ukraine',
        'Wales'
    ];

    var southAmericanTeams = [
        'Argentina',
        'Bolivia',
        'Brazil',
        'Chile',
        'Colombia',
        'Ecuador',
        'Paraguay',
        'Peru',
        'Uruguay',
        'Venezuela'
    ];

    var ligaBBVA = [
        'FC Barcelona',
        'Real Madrid'
    ];

    var allTeams = premierTeams
        .concat(champonshipTeams)
        .concat(europeanTeams)
        .concat(southAmericanTeams)
        .concat(ligaBBVA);

    $("[id^=NewResult_Team]").autocomplete({
        source: allTeams,
        // Wait for two key presses.
        minLength: 2,
        // Give focus once a match is found.
        autoFocus: true
    });
});