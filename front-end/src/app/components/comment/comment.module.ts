import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommentRoutingModule } from './comment-routing.module';
import { CommentComponent } from './comment/comment.component';

@NgModule({
  declarations: [CommentComponent],
  imports: [CommonModule, CommentRoutingModule],
  exports: [CommentComponent],
})
export class CommentModule {}
