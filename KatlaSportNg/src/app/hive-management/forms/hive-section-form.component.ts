import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSection } from '../models/hive-section';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: HiveSectionService
  ) { }

  hiveId = 0;
  existed = false;
  hiveSection = new HiveSection(0,"", "", false, "", 0);

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) {
        this.hiveSection.storeHiveId = p['store-hive-id'];
        return;
      }
      this.service.getHiveSection(p['id']).subscribe(h => {
        this.hiveSection = h;
        this.hiveSection.storeHiveId = p['store-hive-id'];
      });
      this.existed = true;
    });
  }

  navigateToHiveSections() {
    this.router.navigate([`/hive/${this.hiveSection.storeHiveId}/sections`]);
  }

  onCancel() {
    this.navigateToHiveSections();
  }

  onSubmit() {
    if (this.existed) {
      this.service.updateHiveSection(this.hiveSection).subscribe(p => this.navigateToHiveSections());
    } else {
      this.service.addHiveSection(this.hiveSection).subscribe(p => this.navigateToHiveSections());
    }
  }

  onDelete() {
    this.service.setHiveSectionStatus(this.hiveSection.id, true).subscribe(s => this.hiveSection.isDeleted = true);
  }

  onUndelete() {
    this.service.setHiveSectionStatus(this.hiveSection.id, false).subscribe(s => this.hiveSection.isDeleted = false);
  }

  onPurge() {
    this.service.deleteHiveSection(this.hiveSection.id).subscribe(s => this.navigateToHiveSections());
  }
}
