import React from 'react';
import { observer, inject } from 'mobx-react';
import paging from '../../Common/Paging';
import VehicleModel from '././VehicleModel';
import sorting from '../../Common/Sorting';
import filtering from '../../Common/Filtering';

class VehicleModelTable extends React.Component {

	edit = false;
	editModel = null;

	constructor(props) {
		super(props);

		this.updateModel = this.updateModel.bind(this);
		this.onSubmit = this.onSubmit.bind(this);
		this.searchModel = this.searchModel.bind(this);
	}

	componentDidMount() {
		sorting.orderBy = "asc";
		this.props.provider.sorting();
		paging.pageNumber = 1;
		paging.pageSize = 5;
		paging.takePages = 5;
		this.props.provider.pagedModels = this.props.provider.models.slice(paging.pageNumber - 1, paging.pageSize);
		if (this.props.provider.models.length > paging.pageSize) {
			paging.hasNext = true;
		}
	}

	onSubmit = (e) => {
		e.preventDefault();
		if (this.edit) {
			this.editModel.vehicleMakeId = this.refs.vehicleMakeId.value;
			this.editModel.name = this.refs.name.value;
			this.editModel.abrv = this.refs.abrv.value;
			this.props.provider.updateModel(this.editModel.id, this.editModel.vehicleMakeId, this.editModel.name, this.editModel.abrv);
			this.refs.vehicleMakeId.value = "";
			this.refs.name.value = "";
			this.refs.abrv.value = "";
			this.edit = false;
		} else {
			this.props.provider.addModel(this.refs.vehicleMakeId.value, this.refs.name.value, this.refs.abrv.value);
			this.refs.vehicleMakeId.value = "";
			this.refs.name.value = "";
			this.refs.abrv.value = "";
		}

	}

	updateModel = (id) => {
		this.editModel = this.props.provider.models.find(model => model.id === id);
		this.edit = true;
		this.refs.vehicleMakeId.value = this.editModel.vehicleMakeId;
		this.refs.name.value = this.editModel.name;
		this.refs.abrv.value = this.editModel.abrv;
	}

	searchModel = (e) => {
		if (e.key === "Enter") {
			filtering.search = e.target.value;
			this.props.provider.filterOnChange();
		}

	}

	render() {
		return (
			<div>
				<div>
					<form >
						<input type="text" ref="vehicleMakeId" placeholder="Enter Maker Id" />
						<br />
						<input type="text" ref="name" placeholder="Enter Model Name" />
						<br />
						<input type="text" ref="abrv" placeholder="Enter Model Abrv" />
						<button onClick={this.onSubmit} >Submit</button>
					</form>
				</div>
				<input type="search" onKeyPress={this.searchModel} placeholder="Search" name="search" />
				<table border="1">
					<thead>
						<tr>
							<th allign="center"><input type="button" onClick={this.props.provider.makerIdSort} value="MAKER ID" /></th>
							<th allign="center"><input type="button" onClick={this.props.provider.nameSort} value="NAME" /></th>
							<th allign="center"><input type="button" onClick={this.props.provider.abrvSort} value="ABRV" /></th>
						</tr>
					</thead>
					< tbody >
						{
							this.props.provider.pagedModels.map(model => (
								<VehicleModel key={model.id} editModel={this.updateModel} removeModel={this.props.provider.removeModel} model={model} />
							))
						}
					</tbody>
				</table>
				<div>
					{paging.hasPrevious && (<button onClick={this.props.provider.previousPage}>Previous</button>)}
					{paging.hasNext && (<button onClick={this.props.provider.nextPage}>Next</button>)}
				</div>
			</div>
		)
	}
}

export default inject("provider")(observer(VehicleModelTable));