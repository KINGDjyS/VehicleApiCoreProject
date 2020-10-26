import { makeObservable, observable, runInAction } from 'mobx';
import VehicleModelService from './VehicleModelService';
import sorting from '../../Common/Sorting';
import paging from '../../Common/Paging';
import filtering from '../../Common/Filtering';

class VehicleModelAPIProvider {
    constructor() {
        this.vehicleModelService = new VehicleModelService();
        makeObservable(this, {
            modelData: observable,
            status: observable,
            vehicleMakeId: observable,
            name: observable,
            abrv: observable
        })
    }
    testData = [];
    modelData = [];

    isEdit = false;

    id = 0;
    vehicleMakeId = "";
    name = "";
    abrv = "";

    status = "Initial";

    getVehicleModelsAsync = async () => {
        
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
            const data = await this.vehicleModelService.getAsync(urlParams);
            this.testData = data;
            if (this.testData.length === 0) {
                paging.hasNext = false;
            } else {
                paging.hasNext = true;
                runInAction(() => {
                    this.modelData = data;
                });
            }
            
        } catch (error) {
            runInAction(() => {
                this.status = "Error";
            });
        }
    };

    createVehicleModelAsync = async (model) => {
        try {
            const response = await this.vehicleModelService.postAsync(model);
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
        let model = undefined;
        model = await this.vehicleModelService.getOneAsync(this.id);
        runInAction(() => {
            this.vehicleMakeId = model.vehicleMakeId;
            this.name = model.name;
            this.abrv = model.abrv;
        })
    }

    updateVehicleModelAsync = async (model) => {
        try {
            const response = await this.vehicleModelService.putAsync(this.id, model);
            if (response.status === 200) {
                runInAction(() => {
                    console.log("Update")
                    this.status = "Success";
                    paging.pageNumber = 1;
                    sorting.sortBy = "name";
                    this.getVehicleModelsAsync();
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "Error";  
            })
        }
    }

    removeModelAsync = async (id) => {
        try {
            const response = await this.vehicleModelService.deleteAsync(id);
            if (response.status === 200) {
                runInAction(() => {
                    this.status = "Success";
                    paging.pageNumber = 1;
                    sorting.sortBy = "name";
                    this.getVehicleModelsAsync();
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "Error";
            })
        }
    }

    makeSort = () => {
        if (sorting.sortBy === "VehicleMakeId") {
            sorting.sortBy = "VehicleMakeId Desc";
        } else {
            sorting.sortBy = "VehicleMakeId";
        }
        this.getVehicleModelsAsync();
    }

    nameSort = () => {
        if (sorting.sortBy === "") {
            sorting.sortBy = "Name Desc";
        } else {
            sorting.sortBy = "";
        }
        this.getVehicleModelsAsync();
    }

    abrvSort = () => {
        if (sorting.sortBy === "Abrv") {
            sorting.sortBy = "Abrv Desc";
        } else {
            sorting.sortBy = "Abrv";
        }
        this.getVehicleModelsAsync();
    }

    previousPage = () => {
        if (paging.pageNumber > 1) {
            paging.pageNumber -= 1;
            this.getVehicleModelsAsync();
        } else {
            paging.pageNumber = 1;
        }
        
    }

    nextPage = () => {
        if (paging.hasNext) {
            paging.hasPrevious = true;
            paging.pageNumber += 1;
            this.getVehicleModelsAsync();
        }
    }

}

export default new VehicleModelAPIProvider();