import React from 'react';
import { observer, inject } from 'mobx-react';
import paging from '../../Common/Paging';
import VehicleMaker from '../MakersMock/VehicleMaker';
import sorting from '../../Common/Sorting';
import filtering from '../../Common/Filtering';

class VehicleMakerTable extends React.Component {

	edit = false;
	editMaker = null;

	constructor(props) {
		super(props);



		this.updateMaker = this.updateMaker.bind(this);
		this.onSubmit = this.onSubmit.bind(this);
		this.searchMaker = this.searchMaker.bind(this);
    }

	componentDidMount() {
		sorting.orderBy = "asc";
		this.props.provider.sorting();
		paging.pageNumber = 1;
		paging.pageSize = 3;
		paging.takePages = 3;
		this.props.provider.pagedMakers = this.props.provider.makers.slice(paging.pageNumber - 1, paging.pageSize);
		if (this.props.provider.makers.length > paging.pageSize) {
			paging.hasNext = true;
        }
	}

	onSubmit = (e) => {
		e.preventDefault();
		if (this.edit) {
			this.editMaker.name = this.refs.name.value;
			this.editMaker.abrv = this.refs.abrv.value;
			this.props.provider.updateMaker(this.editMaker.id, this.editMaker.name, this.editMaker.abrv);
			this.refs.name.value = "";
			this.refs.abrv.value = "";
			this.edit = false;
		} else {
			this.props.provider.addMaker(this.refs.name.value, this.refs.abrv.value);
			this.refs.name.value = "";
			this.refs.abrv.value = "";
		}
		
	}

	updateMaker = (id) => {
		this.editMaker = this.props.provider.makers.find(maker => maker.id === id);
		this.edit = true;
		this.refs.name.value = this.editMaker.name;
		this.refs.abrv.value = this.editMaker.abrv;
	}

	searchMaker = (e) => {
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
						<input type="text" ref="name" placeholder="Enter Maker Name" />
						<br />
						<input type="text" ref="abrv" placeholder="Enter Maker Abrv" />
						<button onClick={this.onSubmit} >Submit</button>
					</form>
				</div>
				<input type="search" onKeyPress={this.searchMaker} placeholder="Search" name="search" />
				<table border="1">
					<thead>
						<tr>
							<th allign="center"><input type="button" onClick={this.props.provider.nameSort} value="NAME" /></th>
							<th allign="center"><input type="button" onClick={this.props.provider.abrvSort} value="ABRV" /></th>
						</tr>
					</thead>
					< tbody >
						{
							this.props.provider.pagedMakers.map(maker => (
								<VehicleMaker key={maker.id} editMaker={this.updateMaker} removeMaker={this.props.provider.removeMaker} maker={maker} />
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

export default inject("provider")(observer(VehicleMakerTable));