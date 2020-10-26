import { makeObservable, observable, runInAction } from 'mobx';
import paging from '../../Common/Paging';
import sorting from '../../Common/Sorting';
import filtering from '../../Common/Filtering';


class VehicleMakersProvider{

	constructor() {
		makeObservable(this, {
			pagedMakers: observable
        })
    }

	makers = [
		{ id: 1, name: "Bmw", abrv: "BMW" },
		{ id: 2, name: "Jaguar", abrv: "JAG" },
		{ id: 3, name: "Ford", abrv: "FRD" },
		{ id: 4, name: "Nissan", abrv: "NIS" },
		{ id: 5, name: "Volkswagen", abrv: "VW" },
		{ id: 6, name: "Audi", abrv: "AUD" },
		{ id: 7, name: "Bugatti", abrv: "BUG" },
		{ id: 8, name: "Zastava", abrv: "ZST" },
		{ id: 9, name: "Lexus", abrv: "LEX" }
	];
	pagedMakers = [];

	setToPageOne = () => {
		paging.pageNumber = 1;
		paging.takePages = 3;
		this.pagedMakers = this.makers.slice(paging.pageNumber - 1, paging.pageSize);
	}

	setPagingButton = () => {
		if (this.makers.length > paging.takePages) {
			paging.hasNext = true;
			paging.hasPrevious = false;
		} else {
			paging.hasNext = false;
			paging.hasPrevious = false;
        }
    }

	addMaker = (name, abrv) => {
		runInAction(() => {
			if (name !== "" && abrv !== "") {
				let newMaker = {
					id: Math.max(...this.makers.map(maker => maker.id)) + 1,
					name: name,
					abrv: abrv
				}
				this.makers.push(newMaker);
				sorting.orderBy = "asc";
				this.sorting();
				this.setToPageOne();
				this.setPagingButton();
			}
		})


	}

	updateMaker = (id, name, abrv) => {
		runInAction(() => {
			this.pagedMakers.slice().forEach(maker => {
				if (maker.id === id) {
					maker.name = name;
					maker.abrv = abrv;

				}
			});
			this.setToPageOne();
			this.setPagingButton();
        })
		
    }

	removeMaker = (id) => {
		runInAction(() => {
			let tmp = this.makers.filter(maker => {
				if (maker.id !== id) {
					return maker;
				}
			});
			this.makers = tmp;
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
				paging.takePages = 3;
				paging.hasPrevious = false;
				this.pagedMakers = this.makers.filter(maker => maker.name.toLowerCase().includes(filtering.search.toLowerCase())).slice(paging.pageNumber - 1, paging.pageSize);
				if (this.pagedMakers.length > paging.pageSize) {
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
				this.makers.sort((a, b) => a.name < b.name ? 1 : -1);
				sorting.orderBy = "asc";
			} else {
				this.makers.sort((a, b) => a.name > b.name ? 1 : -1);
				sorting.orderBy = "desc";
			}
		} else if (sorting.sortBy === "abrv") {
			if (sorting.orderBy === "desc") {
				this.makers.sort((a, b) => a.abrv < b.abrv ? 1 : -1);
				sorting.orderBy = "asc";
			} else {
				this.makers.sort((a, b) => a.abrv > b.abrv ? 1 : -1);
				sorting.orderBy = "desc";
			}
        }
	}

	nameSort = (e) => {
		runInAction(() => {
			sorting.sortBy = "name";
			this.sorting();
			this.pagedMakers = this.makers.slice(paging.pageNumber - 1, paging.takePages);
		})
	}

	abrvSort = (e) => {
		runInAction(() => {
			sorting.sortBy = "abrv";
			this.sorting();
			this.pagedMakers = this.makers.slice(paging.pageNumber - 1, paging.takePages);
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
			this.pagedMakers = this.makers.slice(paging.pageNumber - 1, paging.takePages);
        })
		
	}

	nextPage = (e) => {
		runInAction(() => {
			paging.hasPrevious = true;
			paging.pageNumber += paging.pageSize;
			paging.takePages += paging.pageSize;
			if (this.makers.length <= paging.takePages) {
				paging.hasNext = false;
			}
			this.pagedMakers = this.makers.slice(paging.pageNumber - 1, paging.takePages);
		})
	}
}

export default new VehicleMakersProvider();

