import { makeObservable, observable, runInAction } from 'mobx';
import VehicleMakeService from './VehicleMakeService';
import sorting from '../../Common/Sorting';
import paging from '../../Common/Paging';
import filtering from '../../Common/Filtering';

class VehicleMakeAPIProvider {
    constructor() {
        this.vehicleMakeService = new VehicleMakeService();
        makeObservable(this, {
            makeData: observable,
            status: observable,
            name: observable,
            abrv: observable
        })
    }
    testData = [];
    makeData = [];

    isEdit = false;

    id = 0;
    name = "";
    abrv = "";

    status = "Initial";

    getVehicleMakersAsync = async () => {

        let params = undefined;
        if (filtering.search !== "") {
            params = {
                SearchName: filtering.search,
                SortBy: sorting.sortBy,
                CurrentPage: paging.pageNumber
            };
        } else {
            params = {
                SortBy: sorting.sortBy,
                CurrentPage: paging.pageNumber
            };
        }

        try {
            const urlParams = new URLSearchParams(Object.entries(params));
            const data = await this.vehicleMakeService.getAsync(urlParams);
            this.testData = data;
            if (this.testData.length === 0) {
                paging.hasNext = false;
            } else {
                paging.hasNext = true;
                runInAction(() => {
                    this.makeData = data;
                });
            }
            
        } catch (error) {
            runInAction(() => {
                this.status = "Error";
            });
        }
    };

    createVehicleMakerAsync = async (maker) => {
        try {
            const response = await this.vehicleMakeService.postAsync(maker);
            if (response.status === 201) {
                runInAction(() => {
                    this.status = "Created";
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "Error";
            })
        }
    }

    edit = async () => {
        this.isEdit = true;
        let maker = undefined;
        maker = await this.vehicleMakeService.getOneAsync(this.id);
        runInAction(() => {
            this.name = maker.name;
            this.abrv = maker.abrv;
        })
    }

    updateVehicleMakerAsync = async (maker) => {
        try {
            const response = await this.vehicleMakeService.putAsync(this.id, maker);
            if (response.status === 200) {
                runInAction(() => {
                    this.status = "Success";
                    paging.pageNumber = 1;
                    sorting.sortBy = "name";
                    this.getVehicleMakersAsync();
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "Error";  
            })
        }
    }

    removeMakerAsync = async (id) => {
        try {
            const response = await this.vehicleMakeService.deleteAsync(id);
            if (response.status === 200) {
                runInAction(() => {
                    this.status = "Success";
                    paging.pageNumber = 1;
                    sorting.sortBy = "name";
                    this.getVehicleMakersAsync();
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "Error";
            })
        }
    }

    nameSort = () => {
        if (sorting.sortBy === "") {
            sorting.sortBy = "Name Desc";
        } else {
            sorting.sortBy = "";
        }
        this.getVehicleMakersAsync();
    }

    abrvSort = () => {
        if (sorting.sortBy === "Abrv") {
            sorting.sortBy = "Abrv Desc";
        } else {
            sorting.sortBy = "Abrv";
        }
        this.getVehicleMakersAsync();
    }

    previousPage = () => {
        if (paging.pageNumber > 1) {
            paging.pageNumber -= 1;
            this.getVehicleMakersAsync();
        } else {
            paging.pageNumber = 1;
        }
        
    }

    nextPage = () => {
        if (paging.hasNext) {
            paging.hasPrevious = true;
            paging.pageNumber += 1;
            this.getVehicleMakersAsync();
        }
    }

}

export default new VehicleMakeAPIProvider();