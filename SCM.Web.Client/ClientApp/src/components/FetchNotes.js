import React, { Component } from 'react';

export class FetchNotes extends Component {
  constructor(props) {
    super(props);
    this.state = { notes: [], loading: true };
  }

  componentDidMount() {
      this.populateNotesData();
  }

  static renderNotesTable(notes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Description</th>
            <th>Created By</th>
            <th>Created on</th>
            <th>Updated By</th>
            <th>Updated on</th>
          </tr>
        </thead>
        <tbody>
          {notes.map(nt =>
              <tr key={nt.noteId}>
              <td>{nt.title}</td>
              <td>{nt.description}</td>
              <td>{nt.createByUserId}</td>
              <td>{nt.createdDate}</td>
              <td>{nt.updateByUserId}</td>
              <td>{nt.updatedDate}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchNotes.renderNotesTable(this.notes);

    return (
      <div>
        <h1 id="tabelLabel" >Notes </h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateNotesData() {
    const response = await fetch('localhost:5001/api/Notes/retriveallnotes');
    const data = await response.json();
    this.setState({ notes: data, loading: false });
  }
}
