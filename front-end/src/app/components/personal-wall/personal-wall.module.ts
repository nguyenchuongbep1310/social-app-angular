import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonalWallComponent } from './personal-wall.component';
import { UploadPostModule } from '../upload-post/upload-post.module';

@NgModule({
  declarations: [PersonalWallComponent],
  imports: [CommonModule, UploadPostModule],
})
export class Personal {}
