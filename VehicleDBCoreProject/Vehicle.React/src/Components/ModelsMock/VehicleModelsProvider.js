import { makeObservable, observable, runInAction } from 'mobx';
import paging from '../../Common/Paging';
import sorting from '../../Common/Sorting';
import filtering from '../../Common/Filtering';


class VehicleModelsProvider {

	constructor() {
		makeObservable(this, {
			pagedModels: observable
		})
	}

	models = [
		{ id: 1, vehicleMakeId: 5, name: "Touareg2", abrv: "TO2" },
		{ id: 2, vehicleMakeId: 1, name: "340 Gran Turismo", abrv: "340"},
		{ id: 3, vehicleMakeId: 3, name: "F-150", abrv: "F15"},
		{ id: 4, vehicleMakeId: 2, name: "XE", abrv: "XE" },
		{ id: 5, vehicleMakeId: 4, name: "GT-R", abrv: "GTR" },
		{ id: 6, vehicleMakeId: 3, name: "Focus", abrv: "FCS" },
		{ id: 7, vehicleMakeId: 5, name: "M550", abrv: "550" },
		{ id: 8, vehicleMakeId: 5, name: "Jetta GLI", abrv: "GLI" },
		{ id: 9, vehicleMakeId: 4, name: "350Z", abrv: "350" },
		{ id: 10, vehicleMakeId: 2, name: "I-Pace", abrv: "IPC" },
		{ id: 11, vehicleMakeId: 4, name: "Frontier", abrv: "FRN" },
		{ id: 12, vehicleMakeId: 2, name: "F-Type Coupe", abrv: "FTP" },
		{ id: 13, vehicleMakeId: 3, name: "Mustang", abrv: "MST" },
		{ id: 14, vehicleMakeId: 5, name: "Arteon", abrv: "ART" },
		{ id: 15, vehicleMakeId: 1, name: "228 Gran Coupe", abrv: "228" }
	];
	pagedModels = [];

	setToPageOne = () => {
		paging.pageNumber = 1;
		paging.takePages = 5;
		this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.pageSize);
	}

	setPagingButton = () => {
		if (this.models.length > paging.takePages) {
			paging.hasNext = true;
			paging.hasPrevious = false;
		} else {
			paging.hasNext = false;
			paging.hasPrevious = false;
		}
	}

	addModel = (vehicleMakeId, name, abrv) => {
		runInAction(() => {
			if (name !== "" && abrv !== "") {
				let newModel = {
					id: Math.max(...this.models.map(maker => maker.id)) + 1,
					vehicleMakeId,
					name,
					abrv
				}
				this.models.push(newModel);
				sorting.orderBy = "asc";
				this.sorting();
				this.setToPageOne();
				this.setPagingButton();
			}
		})


	}

	updateModel = (id, vehicleMakeId, name, abrv) => {
		runInAction(() => {
			this.pagedModels.slice().forEach(model => {
				if (model.id === id) {
					model.vehicleMakeId = vehicleMakeId
					model.name = name;
					model.abrv = abrv;

				}
			});
			this.setToPageOne();
			this.setPagingButton();
		})

	}

	removeModel = (id) => {
		runInAction(() => {
			let tmp = this.models.filter(model => {
				if (model.id !== id) {
					return model;
				}
			});
			this.models = tmp;
			this.setToPageOne();
			this.setPagingButton();
		});
	}

	filterOnChange = () => {
		runInAction(() => {
			if (filtering.search === "") {
				paging.hasNext = true;
				this.setToPageOne();
			} else {
				paging.pageNumber = 1;
				paging.takePages = 5;
				paging.hasPrevious = false;
				this.pagedModels = this.models.filter(model => model.name.toLowerCase().includes(filtering.search.toLowerCase())).slice(paging.pageNumber - 1, paging.pageSize);
				if (this.pagedModels.length > paging.pageSize) {
					paging.hasNext = true;
				} else {
					paging.hasNext = false;
				}
			}

		})

	}

	sorting = () => {
		if (sorting.sortBy === "name") {
			if (sorting.orderBy === "desc") {
				this.models.sort((a, b) => a.name < b.name ? 1 : -1);
				sorting.orderBy = "asc";
			} else {
				this.models.sort((a, b) => a.name > b.name ? 1 : -1);
				sorting.orderBy = "desc";
			}
		} else if (sorting.sortBy === "abrv") {
			if (sorting.orderBy === "desc") {
				this.models.sort((a, b) => a.abrv < b.abrv ? 1 : -1);
				sorting.orderBy = "asc";
			} else {
				this.models.sort((a, b) => a.abrv > b.abrv ? 1 : -1);
				sorting.orderBy = "desc";
			}
		} else if (sorting.sortBy === "makerId") {
			if (sorting.orderBy === "desc") {
				this.models.sort((a, b) => a.vehicleMakeId < b.vehicleMakeId ? 1 : -1);
				sorting.orderBy = "asc";
			} else {
				this.models.sort((a, b) => a.vehicleMakeId > b.vehicleMakeId ? 1 : -1);
				sorting.orderBy = "desc";
			}
		}
	}

	makerIdSort = (e) => {
		runInAction(() => {
			sorting.sortBy = "makerId";
			this.sorting();
			this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.takePages);
		})
	}

	nameSort = (e) => {
		runInAction(() => {
			sorting.sortBy = "name";
			this.sorting();
			this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.takePages);
		})
	}

	abrvSort = (e) => {
		runInAction(() => {
			sorting.sortBy = "abrv";
			this.sorting();
			this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.takePages);
		})
	}

	previousPage = (e) => {
		runInAction(() => {
			if ((paging.pageNumber - paging.pageSize) <= 1) {
				paging.pageNumber = 1;
				paging.hasPrevious = false;
				paging.hasNext = true;
			} else {
				paging.pageNumber -= paging.pageSize;
				paging.hasNext = true;
			}
			paging.takePages -= paging.pageSize;
			this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.takePages);
		})

	}

	nextPage = (e) => {
		runInAction(() => {
			paging.hasPrevious = true;
			paging.pageNumber += paging.pageSize;
			paging.takePages += paging.pageSize;
			if (this.models.length <= paging.takePages) {
				paging.hasNext = false;
			}
			this.pagedModels = this.models.slice(paging.pageNumber - 1, paging.takePages);
		})
	}
}

export default new VehicleModelsProvider();