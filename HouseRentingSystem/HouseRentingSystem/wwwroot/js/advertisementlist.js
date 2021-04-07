fetch("/Advertisement/GetAllAdvertisements").then(res => res.json()).then(data => { console.log(data) });
/*async function requestList() {
    const { date } = await axios.get('/Advertisement/GetAllAdvertisements');
    return data;
}*/
