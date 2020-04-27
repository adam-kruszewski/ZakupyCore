import { Component, OnInit, ChangeDetectorRef, Output, EventEmitter, Input} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {
  fileToUpload: File = null;

  fileName: string;
  fileID: string;

  @Input() id: string;
  @Output() uploaded = new EventEmitter();

  constructor(
    private http: HttpClient,
    private cd: ChangeDetectorRef) {
  }

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);

    const endpoint = '/api/Files';
    const formData: FormData = new FormData();
    formData.append('fileKey', this.fileToUpload, this.fileToUpload.name);

    this.http.post(endpoint, formData).toPromise()
      .then((data) => {
        let success = data != null;

        if (!success)
          window.alert('Nie udało się załadować pliku');
        else {
          let result = data as FileResult[];

          this.fileName = result[0].name;
          this.fileID = result[0].id;

          this.cd.markForCheck();

          this.uploaded.emit({ fileID: this.fileID, fileName: this.fileName });
        }
      });
  }

  ngOnInit() {
  }

}

class FileResult {
  id: string;
  name: string;
}
