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

function AddRestaurant(): void {
    let resto2Add: restaurant =
    {
        id: 0,
        name: document.querySelector<HTMLInputElement>('#name')!.value,
        city: document.querySelector<HTMLInputElement>('#city')!.value,
        state: document.querySelector<HTMLInputElement>('#state')!.value,
        reviews: null

    };
    let xhr: XMLHttpRequest = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status > 199 && this.status < 300) {
            alert('restaurant added!');
            document.querySelector<HTMLInputElement>('#name')!.value = '';
            document.querySelector<HTMLInputElement>('#city')!.value = '';
            document.querySelector<HTMLInputElement>('#state')!.value = '';
            GetAllRestaurants();
        }
    }

    xhr.open('POST', 'https://restaurantrevapi.azurewebsites.net/api/restaurants', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.send(JSON.stringify(resto2Add));
}