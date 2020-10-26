const webApiUrl = "https://localhost:5001/api/VehicleModel";

class VehicleModelService {

    getAsync = async (urlParams) => {

        const options = {
            method: "GET",
        }
        const request = new Request(`${webApiUrl}?${urlParams}`, options);
        const response = await fetch(request).then(resp => resp.json()).then(resp => {
            return resp;
        });

        return response;
    }

    getOneAsync = async (id) => {

        const options = {
            method: "GET",
        }
        const request = new Request(`${webApiUrl}/${id}`, options);
        const response = await fetch(request).then(resp => resp.json()).then(resp => {
            return resp;
        });
        return response;
    }

    postAsync = async (model) => {
        const headers = new Headers();
        headers.append("Content-Type", "application/json");
        var options = {
            method: "POST",
            headers,
            body: JSON.stringify(model)
        }
        const request = new Request(webApiUrl, options);
        const response = await fetch(request);
        return response;
    }

    putAsync = async (id, model) => {
        const headers = new Headers();
        headers.append("Content-Type", "application/json");
        var options = {
            method: "PUT",
            headers,
            body: JSON.stringify(model)
        }
        const request = new Request(`${webApiUrl}/${id}`, options);
        const response = await fetch(request);
        return response;
    }

    deleteAsync = async (id) => {
        const headers = new Headers();
        headers.append("Content-Type", "application/json");
        var options = {
            method: "DELETE",
            headers
        }
        const request = new Request(`${webApiUrl}/${id}`, options);
        const response = await fetch(request);
        return response;
    }
}

export default VehicleModelService;