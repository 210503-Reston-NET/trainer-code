import { restaurant } from "./models/restaurant";

function GetAllRestaurants(): void {
    fetch("https://restaurantrevapi.azurewebsites.net/api/restaurants", {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    })
        .then(response => response.json())
        .then(responseBody => PrintRestaurantsTable(responseBody));
}

function PrintRestaurantsTable(restaurants: restaurant[]): void {
    document.querySelectorAll('#restaurants tbody tr').forEach(row => row.remove());
    //manipulating the dom to populate the restaurant table
    // find the table element we'll be manipulating
    let table: HTMLTableElement | null = document.querySelector("#restaurants tbody");
    if (table) {
        for (let i: number = 0; i < restaurants.length; ++i) {
            //add a row to the table element
            let row: HTMLTableRowElement = table.insertRow(table.rows.length);

            //populate the cells of each row
            let nameCell: HTMLTableCellElement = row.insertCell(0);
            nameCell.innerHTML = restaurants[i].name;

            let cityCell: HTMLTableCellElement = row.insertCell(1);
            cityCell.innerHTML = restaurants[i].city;

            let stateCell: HTMLTableCellElement = row.insertCell(2);
            stateCell.innerHTML = restaurants[i].state;

        }

    }
}