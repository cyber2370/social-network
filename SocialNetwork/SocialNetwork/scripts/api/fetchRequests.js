import fetch from 'isomorphic-fetch';

const queryTypes = {
	GET: "GET",
	POST: "POST",
	PUT: "PUT",
	DELETE: "DELETE"
};

let baseFetchSettings = {
	mode: 'cors'
};

let baseUrl = "http://localhost:55555/"

export function getAsync(specifyingUrl, specifyingSettings = {}) {
	let url = baseUrl + specifyingUrl;

	let settings = Object.assign({}, specifyingSettings, baseAjaxSettings);
	settings.method = queryTypes.GET;

	console.log(specifyingSettings, baseAjaxSettings, settings);

	return fetch(url, settings)
		.then(
			response => response.json()
		);
}

export function postAsync(specifyingUrl, data, specifyingSettings = {}) {
	let url = baseUrl + specifyingUrl;

	let settings = Object.assign({}, specifyingSettings, baseAjaxSettings);
	settings.method = queryTypes.POST;
	settings.body = data;

	return fetch(url, settings)
		.then(
			response => response.json()
		);;
}

export function putAsync(specifyingUrl, data, specifyingSettings = {}) {
	let url = baseUrl + specifyingUrl;

	let settings = Object.assign({}, specifyingSettings, baseAjaxSettings);
	settings.method = queryTypes.PUT;
	settings.body = data;

	return fetch(url, settings)
		.then(
			response => response.json()
		);;
}

export function deleteAsync(specifyingUrl, specifyingSettings = {}) {
	let url = baseUrl + specifyingUrl;

	let settings = Object.assign({}, specifyingSettings, baseAjaxSettings);
	settings.method = queryTypes.DELETE;

	return fetch(url, settings)
		.then(
			response => response.json()
		);;
}